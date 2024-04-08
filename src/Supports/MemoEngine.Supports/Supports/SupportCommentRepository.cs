using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MemoEngine.Supports
{
    public class SupportCommentRepository : ISupportCommentRepository
    {
        private readonly SqlConnection db;

        public SupportCommentRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        public SupportComment Add(SupportComment model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 특정 게시물에 댓글 추가
        /// </summary>
        public void AddComment(SupportComment model)
        {
            //[A] SQL 쿼리문: 댓글 입력 및 게시판 코멘트 수 1 증가
            string sql = @"
                Insert Into SupportsComments (ArticleId, Name, Opinion, Password, UserName)
                Values(@ArticleId, @Name, @Opinion, @Password, @UserName);

                Update Supports Set CommentCount = CommentCount + 1 
                Where Id = @ArticleId
            ";

            //[B] 파라미터 추가
            var parameters = new DynamicParameters();
            parameters.Add("@ArticleId", value: model.ArticleId, dbType: DbType.Int32);
            parameters.Add("@Name", value: model.Name, dbType: DbType.String);
            parameters.Add("@Opinion", value: model.Opinion, dbType: DbType.String);
            parameters.Add("@Password", value: model.Password, dbType: DbType.String);
            parameters.Add("@UserName", value: model.UserName, dbType: DbType.String);

            //[C] 실행 
            db.Execute(sql, parameters, commandType: CommandType.Text);
        }

        public SupportComment Browse(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 댓글 삭제
        /// </summary>
        public int DeleteComment(int articleId, int id, string password)
        {
            return db.Execute(@"
                Delete SupportsComments Where ArticleId = @ArticleId And Id = @Id And Password = @Password;                 
                Update Supports Set CommentCount = CommentCount - 1 Where Id = @ArticleId;
                "
                , new { ArticleId = articleId, Id = id, Password = password }
                , commandType: CommandType.Text);
        }

        public bool Edit(SupportComment model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 특정 게시물에 해당하는 댓글 리스트
        /// </summary>
        public List<SupportComment> GetComments(int articleId)
        {
            return db.Query<SupportComment>(
                "Select * From SupportsComments Where ArticleId = @ArticleId"
                , new { ArticleId = articleId }
                , commandType: CommandType.Text).ToList();
        }
        public List<SupportComment> GetComments(int articleId, string userName)
        {
            //string sql = "Select * From SupportsComments Where ArticleId = @ArticleId And UserName = @UserName";
            string sql = "Select * From SupportsComments Where ArticleId = @ArticleId";
            return db.Query<SupportComment>(
                sql
                , new { ArticleId = articleId, UserName = userName }
                , commandType: CommandType.Text).ToList();
        }

        /// <summary>
        /// 특정 게시물(ArticleId)의 특정 댓글(Id)에 해당하는 댓글 카운트
        /// </summary>
        public int GetCountBy(int articleId, int id, string password)
        {
            string sql = "Select Count(*) From SupportsComments Where ArticleId = @ArticleId And Id = @Id And Password = @Password";
            return db.Query<int>(sql, new { ArticleId = articleId, Id = id, Password = password }, commandType: CommandType.Text).SingleOrDefault();
        }

        /// <summary>
        /// 최근 댓글 리스트 5개 출력
        /// </summary>
        /// <returns></returns>
        public List<SupportComment> GetRecentComments()
        {
            string sql = @"SELECT TOP 5 Id, ArticleId, Opinion, PostDate FROM SupportsComments Order By Id Desc";
            return db.Query<SupportComment>(sql).ToList();
        }

        public int Has()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupportComment> Ordering(OrderOption orderOption)
        {
            throw new NotImplementedException();
        }

        public List<SupportComment> Paging(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<SupportComment> Read()
        {
            throw new NotImplementedException();
        }

        public List<SupportComment> Search(string query)
        {
            throw new NotImplementedException();
        }
    }
}
