using System.Collections.Generic;

namespace MemoEngine.Supports
{
    public interface ISupportCommentRepository : IBreadShop<SupportComment>
    {
        void AddComment(SupportComment model);
        int DeleteComment(int articleId, int id, string password);
        List<SupportComment> GetComments(int articleId);
        List<SupportComment> GetComments(int articleId, string userName);
        int GetCountBy(int articleId, int id, string password);
        List<SupportComment> GetRecentComments();
    }
}
