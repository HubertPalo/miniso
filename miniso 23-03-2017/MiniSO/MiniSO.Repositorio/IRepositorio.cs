using MiniSO.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Repositorio
{
    public interface IRepositorio
    {
        IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null, int? skip = null, int? take = null)
            where TEntity : EntidadBase;

        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
            where TEntity : EntidadBase;

        TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
            where TEntity : EntidadBase;

        TEntity GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
            where TEntity : EntidadBase;

        TEntity GetById<TEntity>(object id)
            where TEntity : EntidadBase;

        int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : EntidadBase;

        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : EntidadBase;

        void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : EntidadBase;

        void CreateRange<TEntity>(IList<TEntity> entities, string createdBy = null)
            where TEntity : EntidadBase;

        void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : EntidadBase;

        void Delete<TEntity>(object id)
            where TEntity : EntidadBase;

        void Delete<TEntity>(TEntity entity)
            where TEntity : EntidadBase;

        /*
        void CreateAnswer(Answer answer);
        void UpdateAnswer(Answer answer, String newDescription);

        void CreateMedal(Medal medal);
        void UpdateMedal(Medal medal, String newName, String newDescription);

        void CreateQuestion(Question question);
        void UpdateQuestion(Question question, String newTitle, String newDescription);

        void CreateQuestionTag(QuestionTag questiontag);

        void CreateTag(Tag tag);

        void CreateUser(User usuario);
        void UpdateUser(User usuario, String newName, String NewEmail, String NewPassword);

        void CreateUserMedal(UserMedal usermedal);
        /*
        void UpdateNombre(alumno2 alumno, String nuevonnombre);

        void CreateAlumno(alumno2 alumno);
        */
        void Save();
    }
}
