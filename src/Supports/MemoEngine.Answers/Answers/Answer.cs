namespace MemoEngine.Answers
{
    public class Answer : ArticleBase
    {
        ///// <summary>
        ///// Id - 일련번호
        ///// </summary>
        //[Display(Name = "번호")]
        //public int Id { get; set; }

        //#region [0] 5W1H: 누가, 언제, 어디서, 무엇을, 어떻게, 왜
        ///// <summary>
        ///// 작성자
        ///// </summary>
        //[Display(Name = "작성자")]
        //[Required(ErrorMessage = "* 이름을 작성해 주세요.")]
        //public string Name { get; set; }

        ///// <summary>
        ///// 작성일
        ///// </summary>
        //[Display(Name = "작성일")]
        //public DateTime PostDate { get; set; }

        ///// <summary>
        ///// 작성지 IP 주소
        ///// </summary>
        //[Display(Name = "작성IP")]
        //public string PostIp { get; set; }

        ///// <summary>
        ///// 제목
        ///// </summary>
        //[Display(Name = "제목")]
        //[Required(ErrorMessage = "* 제목을 작성해 주세요.")]
        //public string Title { get; set; }

        ///// <summary>
        ///// 내용
        ///// </summary>
        //[Display(Name = "내용")]
        //[Required(ErrorMessage = "* 내용을 작성해 주세요.")]
        //public string Content { get; set; }

        ///// <summary>
        ///// 카테고리: Notice, Free, Data, Photo, ...
        ///// </summary>
        //[Display(Name = "카테고리")]
        //public string Category { get; set; }
        //#endregion
        
        //#region [1] 기본형 게시판 관련 주요 컬럼
        ///// <summary>
        ///// 작성자 이메일
        ///// </summary>
        //[EmailAddress(ErrorMessage = "* 이메일을 정확히 입력하세요.")]
        //public string Email { get; set; }

        ///// <summary>
        ///// 비밀번호
        ///// </summary>
        //[Display(Name = "비밀번호")]
        //[Required(ErrorMessage = "* 비밀번호를 작성해 주세요.")]
        //public string Password { get; set; }

        ///// <summary>
        ///// 조회수
        ///// </summary>
        //[Display(Name = "조회수")]
        //public int ReadCount { get; set; }

        ///// <summary>
        ///// 인코딩: Text, HTML, Mixed
        ///// </summary>
        //[Display(Name = "인코딩")]
        //public string Encoding { get; set; } = "Text";

        ///// <summary>
        ///// 홈페이지 
        ///// </summary>
        //[Display(Name = "홈페이지")]
        //public string Homepage { get; set; }

        ///// <summary>
        ///// 수정일
        ///// </summary>
        //[Display(Name = "수정일")]
        //public DateTime ModifyDate { get; set; }

        ///// <summary>
        ///// 수정 IP 주소
        ///// </summary>
        //[Display(Name = "수정IP")]
        //public string ModifyIp { get; set; }

        ///// <summary>
        ///// 댓글수 
        ///// </summary>
        //[Display(Name = "댓글수")]
        //public int CommentCount { get; set; }
        //#endregion
        
        //#region [2] 자료실 게시판 관련 주요 컬럼
        ///// <summary>
        ///// 파일명
        ///// </summary>
        //[Display(Name = "파일")]
        //public string FileName { get; set; }

        ///// <summary>
        ///// 파일크기
        ///// </summary>
        //[Display(Name = "파일크기")]
        //public int FileSize { get; set; }

        ///// <summary>
        ///// 다운수 
        ///// </summary>
        //[Display(Name = "다운수")]
        //public int DownCount { get; set; }
        //#endregion
        
        //#region [3] 답변형 게시판 관련 주요 컬럼: 참조 계층 관련(Ref, ...)
        ///// <summary>
        ///// 참조번호
        ///// </summary>
        //[Display(Name = "참조번호")]
        //public int Ref { get; set; }

        ///// <summary>
        ///// 들여쓰기, 레벨
        ///// </summary>
        //[Display(Name = "들여쓰기")]
        //public int Step { get; set; }

        ///// <summary>
        ///// 참조 순서
        ///// </summary>
        //[Display(Name = "참조순서")]
        //public int RefOrder { get; set; }

        ///// <summary>
        ///// 답변수
        ///// </summary>
        //[Display(Name = "답변수")]
        //public int AnswerNum { get; set; }

        ///// <summary>
        ///// 부모글 번호
        ///// </summary>
        //[Display(Name = "부모번호")]
        //public int ParentNum { get; set; }
        //#endregion

        //#region [!] 기타 확장 기능 및 참조 관련 주요 컬럼
        ///// <summary>
        ///// 게시물의 일련번호
        ///// </summary>
        //[Display(Name = "번호")]
        //public int Num { get; set; }

        ///// <summary>
        ///// 회원제(Private) 게시판의 사용자 UID 
        ///// </summary>
        //[Display(Name = "사용자UID")]
        //public int UID { get; set; }

        ///// <summary>
        ///// 회원제(Private) 게시판의 사용자 UID == UserId
        ///// </summary>
        //[Display(Name = "사용자UID")]
        //public int UserId { get; set; }

        ///// <summary>
        ///// 사용자 아이디
        ///// </summary>
        //public string UserName { get; set; }

        ///// <summary>
        ///// 구분(카테고리) 번호 => Divisions 테이블의 Id 
        ///// </summary>
        //public int DivisionId { get; set; }

        ///// <summary>
        ///// 상품 카테고리 Id
        ///// </summary>
        //public int CategoryId { get; set; }

        ///// <summary>
        ///// 게시판(Boards) 테이블의 Id
        ///// </summary>
        //public int BoardId { get; set; }

        ///// <summary>
        ///// 응용 프로그램 Id
        ///// </summary>
        //public int ApplicationId { get; set; }
        //#endregion
    }
}
