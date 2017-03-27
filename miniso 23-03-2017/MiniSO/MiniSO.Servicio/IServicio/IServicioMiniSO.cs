using MiniSO.Entidades;
using MiniSO.Entidades.WebApiModels;
using MiniSO.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Servicio
{
    public interface IServicioMiniSO
    {
        void AddAnswers(IList<Answer> answers);
        int AddAnswer(Answer answer);
        void EditAnswer(int answer_id, String restofdata);
        void DeleteAnswer(int answer_id);

        void AddMedals(IList<Medal> medals);
        void AddMedal(Medal medal);
        void EditMedal(int medal_id, String newName, String newDescription);
        void DeleteMedal(int medal_id);

        void AddQuestions(IList<Question> questions);
        void AddQuestion(Question question);
        bool IsValid(string username, string password);
        
        void EditQuestion(int question_id, String newTitle, String newDescription);
        UserModel GetUserById(int id);
        QuestionModel GetQuestionById(int id);
        IEnumerable<QuestionModel> GetAllQuestionsFromUser(int user_id);
        void DeleteQuestion(int question_id);

        void AddQuestionTag(QuestionTag questiontag);
        QuestionModel getLastQuestionByUserId(int user_id);
        Question getEmptyQuestion();
        void DeleteQuestionTag(int questiontag_id);
        
        void AddTags(IList<Tag> tags);
        void AddTag(Tag tag);
        void DeleteTag(int tag_id);

        void AddUsers(IList<User> users);
        
        void AddUser(User user);
        void AddUser(string v1, string v2, string v3);
        void EditUser(int user_id, String newName, String newEmail, String newPassword);
        void DeleteUser(int user_id);
        IList<UserModel> GetAllValidUsers();

        void AddUserMedals(IList<UserMedal> usermedal);
        void AddUserMedal(UserMedal usermedal);
        UserModel GetUserByUserNameAndPassword(string username, string password);
        void DeleteUserMedal(int usermedal_id);

        User GetEmptyUser();
        int GetId(string username, string password);

        UserView GetEmptyUserView();

        bool IfUserEmailIsAlreadyRegistered(string email);
        bool IfUserNameIsAlreadyRegistered(string username);

    }
}
