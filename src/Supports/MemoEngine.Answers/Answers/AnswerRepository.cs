using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Answers
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly SqlConnection db;

        public AnswerRepository(string connectionString)
        {
            db = new SqlConnection(connectionString); 
        }

        /// <summary>
        /// 데이터 저장, 수정, 답변 공통 메서드
        /// </summary>
        public int SaveOrUpdate(ArticleBase model, BoardWriteFormType formType)
        {
            int r = 0;

            // 파라미터 추가
            var p = new DynamicParameters();

            //[a] 공통
            p.Add("@Name", value: model.Name, dbType: DbType.String);
            p.Add("@Email", value: model.Email, dbType: DbType.String);
            p.Add("@Title", value: model.Title, dbType: DbType.String);
            p.Add("@Content", value: model.Content, dbType: DbType.String);
            p.Add("@Password", value: model.Password, dbType: DbType.String);
            p.Add("@Encoding", value: model.Encoding, dbType: DbType.String);
            p.Add("@Homepage", value: model.Homepage, dbType: DbType.String);
            p.Add("@FileName", value: model.FileName, dbType: DbType.String);
            p.Add("@FileSize", value: model.FileSize, dbType: DbType.Int32);
            p.Add("@Category", value: model.Category, dbType: DbType.String); 

            switch (formType)
            {
                case BoardWriteFormType.Write:
                    //[b] 글쓰기 전용
                    p.Add("@PostIp", value: model.PostIp, dbType: DbType.String);

                    r = db.Execute("AnswersWrite", p, commandType: CommandType.StoredProcedure);
                    break;
                case BoardWriteFormType.Modify:
                    //[b] 수정하기 전용
                    p.Add("@ModifyIp", value: model.ModifyIp, dbType: DbType.String);
                    p.Add("@Id", value: model.Id, dbType: DbType.Int32);

                    r = db.Execute("AnswersModify", p, commandType: CommandType.StoredProcedure);
                    break;
                case BoardWriteFormType.Reply:
                    //[b] 답변쓰기 전용
                    p.Add("@PostIp", value: model.PostIp, dbType: DbType.String);
                    p.Add("@ParentNum", value: model.ParentNum, dbType: DbType.Int32);

                    r = db.Execute("AnswersReply", p, commandType: CommandType.StoredProcedure);
                    break;
            }

            return r;
        }

        public ArticleBase Add(ArticleBase model)
        {
            try
            {
                int id = SaveOrUpdate(model, BoardWriteFormType.Write);
                model.Id = id;
                return model; 
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message); // 로깅 처리 권장 영역
            }
        }

        public ArticleBase Browse(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 삭제 패턴
        /// </summary>
        public int Delete(int id, string password)
        {
            return db.Execute("AnswersDelete", new { Id = id, Password = password }, 
                commandType: CommandType.StoredProcedure);
        }

        public bool Edit(ArticleBase model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 게시판 리스트
        /// GetAll(), FindAll() 형태로 주로 사용
        /// 또는
        /// GetNotes(), GetComments(), GetAnswers() 형태로도 많이 사용
        /// </summary>
        /// <param name="pageNumber">페이지 번호</param>
        /// <param name="pageSize">한 페이지에 표시할 레코드 수</param>
        public List<ArticleBase> GetAll(int pageNumber, int pageSize = 10)
        {
            try
            {
                var parameters = new DynamicParameters(new { PageNumber = pageNumber, PageSize = pageSize });
                return db.Query<ArticleBase>("AnswersList", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public List<ArticleBase> GetAnswers(int pageNumber, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 상세 패턴: 단일 레코드값 반환
        /// </summary>
        public ArticleBase GetById(int id)
        {
            var parameters = new DynamicParameters(new { Id = id });
            return db.Query<ArticleBase>("AnswersDetails", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }

        /// <summary>
        /// 전체 레코드 수 반환: Answers 테이블의 모든 레코드 수 
        /// </summary>
        public int GetCountAll()
        {
            try
            {
                return db.Query<int>("Select Count(*) From Answers").SingleOrDefault();
            }
            catch (System.Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 검색 결과에 따른 총 레코드 카운트
        /// </summary>
        public int GetCountBySearch(string searchField, string searchQuery)
        {
            try
            {
                return db.Query<int>("AnswersSearchCount", new
                {
                    SearchField = searchField,
                    SearchQuery = searchQuery
                },
                    commandType: CommandType.StoredProcedure)
                    .SingleOrDefault();

            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Id에 해당하는 첨부된 파일명 반환
        /// </summary>
        public string GetFileNameById(int id)
        {
            return db.Query<string>("Select FileName From Answers Where Id = @Id", new { Id = id }).SingleOrDefault();
        }

        public List<ArticleBase> GetNewPhotos()
        {
            throw new NotImplementedException();
        }

        public List<ArticleBase> GetRecentPosts(int number = 5)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 검색 결과 리스트
        /// </summary>
        public List<ArticleBase> GetSearchAll(string searchField, string searchQuery, int pageNumber, int pageSize = 10)
        {
            var parameters = new DynamicParameters(
                new { SearchField = searchField, SearchQuery = searchQuery, PageNumber = pageNumber, PageSize = pageSize });
            return db.Query<ArticleBase>("AnswersSearchList", parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public List<ArticleBase> GetSummaryByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public int Has()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleBase> Ordering(OrderOption orderOption)
        {
            throw new NotImplementedException();
        }

        public List<ArticleBase> Paging(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Pinned(int id)
        {
            throw new NotImplementedException();
        }

        public List<ArticleBase> Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 답변달기
        /// </summary>
        public void ReplyModel(ArticleBase model)
        {
            try
            {
                SaveOrUpdate(model, BoardWriteFormType.Reply);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public List<ArticleBase> Search(string query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 다운 카운트 1 증가
        /// </summary>
        public void UpdateDownCount(string fileName)
        {
            db.Execute("Update Answers Set DownCount = DownCount + 1 Where FileName = @FileName", new { FileName = fileName });
        }
        public void UpdateDownCountById(int id)
        {
            var p = new DynamicParameters(new { Id = id });
            db.Execute("Update Answers Set DownCount = DownCount + 1 Where Id = @Id", p, commandType: CommandType.Text);
        }

        /// <summary>
        /// 수정할 데이터를 SaveOrUpdate() 메서드에 전달
        /// </summary>
        public int UpdateModel(ArticleBase model)
        {
            int r = 0;
            try
            {
                r = SaveOrUpdate(model, BoardWriteFormType.Modify);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return r;
        }

        public ArticleBase WriteModel(ArticleBase model)
        {
            throw new NotImplementedException();
        }
    }
}
