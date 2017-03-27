using MiniSO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace MiniSO.Repositorio
{
    public class RepositorioEF<TContext> : IRepositorio
            where TContext : DbContext
    {
        protected readonly TContext context;

        public RepositorioEF(TContext _context)
        {
            context = _context;
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null)
            where TEntity : EntidadBase
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null, int? skip = null, int? take = null)
            where TEntity : EntidadBase
        {
            return GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToList();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null, int? skip = null, int? take = null)
            where TEntity : EntidadBase
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
            where TEntity : EntidadBase
        {
            return GetQueryable<TEntity>(filter, null, includeProperties).SingleOrDefault();
        }

        public TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
            where TEntity : EntidadBase
        {
            return GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public TEntity GetById<TEntity>(object id)
            where TEntity : EntidadBase
        {
            return context.Set<TEntity>().Find(id);
        }

        public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : EntidadBase
        {
            return GetQueryable<TEntity>(filter).Count();
        }

        public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : EntidadBase
        {
            return GetQueryable<TEntity>(filter).Any();
        }

        public void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : EntidadBase
        {
            entity.Register_date = DateTime.UtcNow;
            entity.Last_edit_date = DateTime.UtcNow;
            entity.Status = "A";
            /*
            entity.FechaCrea = DateTime.UtcNow;
            entity.UsuarioCrea = createdBy == null ? "admin" : createdBy;
            entity.FechaModifica = DateTime.UtcNow;
            entity.UsuarioModifica = createdBy == null ? "admin" : createdBy;
            entity.Estado = "A";
            */
            context.Set<TEntity>().Add(entity);
        }

        public void CreateRange<TEntity>(IList<TEntity> entities, string createdBy = null) where TEntity : EntidadBase
        {
            foreach (var entity in entities)
            {
                entity.Register_date = DateTime.UtcNow;
                entity.Last_edit_date = DateTime.UtcNow;
                entity.Status = "A";
                /*
                entity.FechaCrea = DateTime.UtcNow;
                entity.UsuarioCrea = createdBy == null ? "admin" : createdBy;
                entity.FechaModifica = DateTime.UtcNow;
                entity.UsuarioModifica = createdBy == null ? "admin" : createdBy;
                entity.Estado = "A";
                */
            }
            context.Set<TEntity>().AddRange(entities);
        }

        public void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : EntidadBase
        {
            entity.Last_edit_date = DateTime.UtcNow;
            /*
            entity.FechaModifica = DateTime.UtcNow;
            entity.UsuarioModifica = modifiedBy == null ? "admin" : modifiedBy;
            */
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(object id)
            where TEntity : EntidadBase
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : EntidadBase
        {
            /*
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            */
            entity.Status = "D";
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }

        public IList<TObject> ExecuteSP<TObject>(string spName, IList<System.Data.SqlClient.SqlParameter> parameters)
        {
            try
            {
                string parString = "@" + parameters[0].ParameterName;

                for (int i = 1; i < parameters.Count; i++)
                {
                    parString += ", @" + parameters[i].ParameterName;
                }

                object[] parametros = new object[parameters.Count];

                for (int i = 0; i < parameters.Count; i++)
                {
                    parametros[i] = parameters[i];
                }

                return context.Database.SqlQuery<TObject>("exec " + spName + " " + parString, parametros).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /*
        public void CreateAnswer(Answer answer)
        {

        }
        void UpdateAnswer(Answer answer, String newDescription)
        {

        }

        void CreateMedal(Medal medal) { }
        void UpdateMedal(Medal medal, String newName, String newDescription);

        void CreateQuestion(Question question);
        void UpdateQuestion(Question question, String newTitle, String newDescription);

        void CreateQuestionTag(QuestionTag questiontag);

        void CreateTag(Tag tag);

        void CreateUser(User usuario);
        void UpdateUser(User usuario, String newName, String NewEmail, String NewPassword);

        void CreateUserMedal(UserMedal usermedal);

        /*
        public void UpdateNombre(alumno2 alumno, String nuevonombre)
        {
            alumno.alumno2nombre = nuevonombre;

            context.Set<alumno2>().Attach(alumno);
            context.Entry(alumno).State = EntityState.Modified;
        }

        public void CreateAlumno(alumno2 alumno)
        {
            Create<alumno2>(alumno);
        }
        */
    }
}