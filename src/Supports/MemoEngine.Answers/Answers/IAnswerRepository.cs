using System.Collections.Generic;

namespace MemoEngine.Answers
{
    public interface IAnswerRepository : IBreadShop<ArticleBase>
    {
        int Delete(int id, string password);

        List<ArticleBase> GetAnswers(int pageNumber, int pageSize = 10);

        /// <summary>
        /// 전체 레코드 수 반환: Answers 테이블의 모든 레코드 수 
        /// </summary>
        int GetCountAll();

        /// <summary>
        /// 검색 결과에 따른 총 레코드 카운트
        /// </summary>
        int GetCountBySearch(string searchField, string searchQuery);

        /// <summary>
        /// 게시판 리스트
        /// GetAll(), FindAll() 형태로 주로 사용
        /// 또는
        /// GetNotes(), GetComments(), GetAnswers() 형태로도 많이 사용
        /// </summary>
        /// <param name="pageNumber">페이지 번호</param>
        /// <param name="pageSize">한 페이지에 표시할 레코드 수</param>
        List<ArticleBase> GetAll(int pageNumber, int pageSize = 10);

        /// <summary>
        /// 검색 결과 리스트 
        /// </summary>
        List<ArticleBase> GetSearchAll(
            string searchField, string searchQuery, int pageNumber, int pageSize = 10);

        List<ArticleBase> GetSummaryByCategory(string category);

        string GetFileNameById(int id);

        List<ArticleBase> GetNewPhotos();

        ArticleBase GetById(int id);

        List<ArticleBase> GetRecentPosts(int number = 5);

        void Pinned(int id);

        void ReplyModel(ArticleBase model);

        int SaveOrUpdate(ArticleBase n, BoardWriteFormType formType);

        void UpdateDownCount(string fileName);

        void UpdateDownCountById(int id);

        int UpdateModel(ArticleBase model);

        ArticleBase WriteModel(ArticleBase model); 
    }
}
