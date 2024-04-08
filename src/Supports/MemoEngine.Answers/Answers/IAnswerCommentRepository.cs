using System.Collections.Generic;

namespace MemoEngine.Answers
{
    public interface IAnswerCommentRepository : IBreadShop<AnswerComment>
    {
        void AddComment(AnswerComment model);
        int DeleteComment(int articleId, int id, string password);
        List<AnswerComment> GetComments(int articleId);
        int GetCountBy(int articleId, int id, string password);
        List<AnswerComment> GetRecentComments();
    }
}
