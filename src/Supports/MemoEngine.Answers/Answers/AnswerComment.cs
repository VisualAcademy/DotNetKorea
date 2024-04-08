using System;
using System.ComponentModel.DataAnnotations;

namespace MemoEngine.Answers
{
    public class AnswerComment
    {
        /// <summary>
        /// Id - 일련번호
        /// </summary>
        [Display(Name = "번호")]
        public int Id { get; set; }
        
        /// <summary>
        /// 게시판 아티클 번호 
        /// </summary>
        public int ArticleId { get; set; }

        #region [0] 5W1H: 누가, 언제, 어디서, 무엇을, 어떻게, 왜
        /// <summary>
        /// 작성자
        /// </summary>
        [Display(Name = "작성자")]
        [Required(ErrorMessage = "* 이름을 작성해 주세요.")]
        public string Name { get; set; }

        /// <summary>
        /// 작성일
        /// </summary>
        [Display(Name = "작성일")]
        public DateTime PostDate { get; set; }

        /// <summary>
        /// 작성지 IP 주소
        /// </summary>
        [Display(Name = "작성IP")]
        public string PostIp { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        [Display(Name = "제목")]
        [Required(ErrorMessage = "* 제목을 작성해 주세요.")]
        public string Title { get; set; }

        /// <summary>
        /// 내용
        /// </summary>
        [Display(Name = "내용")]
        [Required(ErrorMessage = "* 내용을 작성해 주세요.")]
        public string Content { get; set; }

        /// <summary>
        /// 카테고리: Notice, Free, Data, Photo, ...
        /// </summary>
        [Display(Name = "카테고리")]
        public string Category { get; set; }
        #endregion
        
        #region [1] 댓글 관련 주요 컬럼: 레거시
        /// <summary>
        /// 의견 == 코멘트
        /// </summary>
        [Required(ErrorMessage = "의견을 입력하세요.")]
        public string Opinion { get; set; }

        /// <summary>
        /// 게시판 이름
        /// </summary>
        public string BoardName { get; set; }

        /// <summary>
        /// 암호
        /// </summary>
        [Required(ErrorMessage = "암호를 입력하세요.")]
        public string Password { get; set; }
        #endregion

        #region [!] 기타 확장 기능 및 참조 관련 주요 컬럼
        /// <summary>
        /// 일련번호
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 사용자 UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 카테고리 ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 게시판 아티클 번호 
        /// </summary>
        public int BoardId { get; set; }

        /// <summary>
        /// 응용 프로그램 ID
        /// </summary>
        public int ApplicationId { get; set; }
        #endregion
    }
}
