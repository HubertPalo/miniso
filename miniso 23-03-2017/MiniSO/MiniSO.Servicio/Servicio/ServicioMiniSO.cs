using MiniSO.Entidades;
using MiniSO.Entidades.WebApiModels;
using MiniSO.Repositorio;
using MiniSO.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Servicio
{
    public class ServicioMiniSO : IServicioMiniSO
    {
        protected readonly IRepositorio repositorio;

        public ServicioMiniSO(IRepositorio _repositorio)
        {
            repositorio = _repositorio;
        }

        public void AddAnswers(IList<Answer> answers)
        {
            repositorio.CreateRange<Answer>(answers);
            repositorio.Save();
        }

        public int AddAnswer(Answer answer)
        {
            User usuario = repositorio.GetById<User>(answer.User_id);
            Question question = repositorio.GetById<Question>(answer.Question_id);

            if (usuario != null && question != null)
            {
                repositorio.Create<Answer>(answer);
                repositorio.Save();
                return getAnswerId(answer.Question_id, answer.User_id);
            }
            else
            {
                return -1;
            }

            
        }

        public int getAnswerId(int question_id, int user_id)
        {
            Answer answer = repositorio.Get<Answer>(a => a.Question_id == question_id && a.User_id == user_id).FirstOrDefault<Answer>();
            if (answer != null)
                return answer.Id;
            return -1;
        }

        public void EditAnswer(int answer_id, String newDescription)
        {
            Answer answer = repositorio.GetById<Answer>(answer_id);
            answer.Description = newDescription;
            repositorio.Update<Answer>(answer);
            repositorio.Save();
        }
        public void DeleteAnswer(int answer_id)
        {
            Answer answer = repositorio.GetById<Answer>(answer_id);
            repositorio.Delete<Answer>(answer);
            repositorio.Save();
        }

        public void AddMedals(IList<Medal> medals)
        {
            repositorio.CreateRange<Medal>(medals);
            repositorio.Save();
        }
        public void AddMedal(Medal medal)
        {
            repositorio.Create<Medal>(medal);
        }
        public void EditMedal(int medal_id, String newName, String newDescription)
        {
            Medal medal = repositorio.GetById<Medal>(medal_id);
            medal.Name = newName;
            medal.Description = newDescription;
            repositorio.Update<Medal>(medal);
            repositorio.Save();
        }
        public void DeleteMedal(int medal_id)
        {
            Medal medal = repositorio.GetById<Medal>(medal_id);
            repositorio.Delete<Medal>(medal);
            repositorio.Save();
        }

        public void AddQuestions(IList<Question> questions)
        {
            repositorio.CreateRange<Question>(questions);
            repositorio.Save();
        }
        public void AddQuestion(Question question)
        {
            repositorio.Create<Question>(question);
            repositorio.Save();
        }
        public void EditQuestion(int question_id, String newTitle, String newDescription)
        {
            Question question = repositorio.GetById<Question>(question_id);
            question.Title = newTitle;
            question.Description = newDescription;
            repositorio.Update<Question>(question);
            repositorio.Save();
        }
        public void DeleteQuestion(int question_id)
        {
            Question question = repositorio.GetById<Question>(question_id);
            repositorio.Delete<Question>(question);
            repositorio.Save();
        }

        public void AddQuestionTag(QuestionTag questiontag)
        {
            repositorio.Create<QuestionTag>(questiontag);
            repositorio.Save();
        }
        public void DeleteQuestionTag(int questiontag_id)
        {
            QuestionTag questiontag= repositorio.GetById<QuestionTag>(questiontag_id);
            repositorio.Delete<QuestionTag>(questiontag);
            repositorio.Save();
        }

        public void AddTags(IList<Tag> tags)
        {
            repositorio.CreateRange<Tag>(tags);
            repositorio.Save();
        }
        public void AddTag(Tag tag)
        {
            repositorio.Create<Tag>(tag);
            repositorio.Save();
        }
        public void DeleteTag(int tag_id)
        {
            Tag tag = repositorio.GetById<Tag>(tag_id);
            repositorio.Delete<Tag>(tag);
            repositorio.Save();
        }

        public void AddUsers(IList<User> users)
        {
            repositorio.CreateRange<User>(users);
            repositorio.Save();
        }
        public void AddUser(User user)
        {
            repositorio.Create<User>(user);
            repositorio.Save();
        }
        public void AddUser(string username, string email, string password)
        {

            User usuario = new User();
            usuario.Name = username;
            usuario.Email = email;
            usuario.Password = password;
            repositorio.Create<User>(usuario);
            repositorio.Save();
        }

        public void EditUser(int user_id, String newName, String newEmail, String newPassword)
        {
            User user = repositorio.GetById<User>(user_id);
            user.Name = newName;
            user.Password = newPassword;
            user.Email = newEmail;
            repositorio.Update<User>(user);
            repositorio.Save();
        }
        public void DeleteUser(int user_id)
        {
            User user = repositorio.GetById<User>(user_id);
            repositorio.Delete<User>(user);
            repositorio.Save();
        }

        public void AddUserMedals(IList<UserMedal> usermedal)
        {
            repositorio.CreateRange<UserMedal>(usermedal);
            repositorio.Save();
        }
        public void AddUserMedal(UserMedal usermedal)
        {
            repositorio.Create<UserMedal>(usermedal);
            repositorio.Save();
        }
        public void DeleteUserMedal(int usermedal_id)
        {
            UserMedal usermedal = repositorio.GetById<UserMedal>(usermedal_id);
            repositorio.Delete<UserMedal>(usermedal);
            repositorio.Save();
        }

        // A partir de aqui se empiezan a manejar otros servicios (y el R de CRUD)
        public IList<UserModel> GetAllValidUsers()
        {
            IList<User> listado = repositorio.GetAll<User>().ToList();
            IList<UserModel> soloA = new List<UserModel>();
            foreach (User usuario in listado)
            {
                if (usuario.Status.Equals("A"))
                    soloA.Add(new UserModel(usuario));
            }

            return soloA;
        }

        public bool SeeIfUserExists(String userName, String userPassword)
        {
            IList<User> listado = repositorio.GetAll<User>().ToList();
            foreach (User usuario in listado)
            {
                if (usuario.Name.Equals(userName) && usuario.Password.Equals(userPassword) && usuario.Status.Equals("A"))
                    return true;
            }
            return false;
        }

        public User GetEmptyUser()
        {
            User usuario = new User();
            usuario.Name = "EmptyUser";
            usuario.Password = "EmptyPassword";
            usuario.Email = "EmptyEmail";
            usuario.Id = -1;
            usuario.Register_date = DateTime.Now;
            usuario.Last_edit_date = DateTime.Now;
            usuario.Status = "A";
            return usuario;
        }

        public UserView GetEmptyUserView()
        {
            UserView usuario = new UserView();
            usuario.UserName = "";
            usuario.UserPassword = "";
            usuario.UserEmail = "";
            usuario.ConfirmPassword = "";
            return usuario;
        }

        public bool IsValid(string username, string password)
        {
            var listado = repositorio.GetAll<User>().ToList();
            foreach (User usuario in listado)
            {
                if (usuario.Name.Equals(username) && usuario.Password.Equals(password))
                    return true;
            }
            return false;
        }
        
        public int GetId(string username, string password)
        {
            var listado = repositorio.GetAll<User>().ToList();
            foreach (User usuario in listado)
            {
                if (usuario.Name.Equals(username) && usuario.Password.Equals(password))
                    return usuario.Id;
            }
            return -1;
        }

        public bool IfUserEmailIsAlreadyRegistered(string email)
        {
            var listado = repositorio.GetAll<User>().ToList();
            foreach (User usuario in listado)
            {
                if (usuario.Email.Equals(email))
                    return true;
            }
            return false;
        }

        public bool IfUserNameIsAlreadyRegistered(string username)
        {
            var listado = repositorio.GetAll<User>().ToList();
            foreach (User usuario in listado)
            {
                if (usuario.Name.Equals(username))
                    return true;
            }
            return false;
        }

        public UserModel GetUserByUserNameAndPassword(string username, string password)
        {

            var listado = repositorio.GetAll<User>().ToList();
            foreach (User usuario in listado)
            {
                if (usuario.Name.Equals(username) && usuario.Password.Equals(password))
                    return new UserModel(usuario);
            }
            return new UserModel(GetEmptyUser());
        }

        public QuestionModel getLastQuestionByUserId(int user_id)
        {
            int ultimoid = 0;
            var lista_preguntas_usuario = repositorio.Get<Question>(q => q.User_id == user_id);
            if (lista_preguntas_usuario == null)
            {
                return new QuestionModel(getEmptyQuestion());
            }

            Question returned_question = null;
            foreach (Question question in lista_preguntas_usuario)
            {
                if (ultimoid < question.Id)
                {
                    ultimoid = question.Id;
                    returned_question = question;
                }
            }
            return new QuestionModel(returned_question);
        }

        public Question getEmptyQuestion()
        {
            Question question = new Question();
            question.Id = -1;
            question.Title = "MetodoUsado: getEmptyQuestion()";
            question.Description = "MetodoUsado: getEmptyQuestion()";
            question.User_id = -1;

            return question;
        }

        public QuestionModel GetQuestionById(int id)
        {
            Question question = repositorio.GetById<Question>(id);
            if (question == null)
                return new QuestionModel(getEmptyQuestion());
            return new QuestionModel(question); 
        }

        public UserModel GetUserById(int id)
        {
            var listado = GetAllValidUsers();
            foreach (UserModel usuario in listado)
            {
                if (usuario.Id == id)
                    return usuario;
            }
            return new UserModel(GetEmptyUser());
        }

        public IEnumerable<QuestionModel> GetAllQuestionsFromUser(int user_id)
        {
            var lista_preguntas_usuario = repositorio.Get<Question>(q => q.User_id == user_id);
            IList<QuestionModel> lista_questionmodel = new List<QuestionModel>();
            foreach (Question question in lista_preguntas_usuario)
            {
                lista_questionmodel.Add(new QuestionModel(question));
            }

            return lista_questionmodel;
        }

        

    }
}
