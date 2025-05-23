using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_02_Advanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //3. Pack URI
        //3-1. 상태 기억용 변수 생성
        private bool isAngry = true;

        //3-2. 이미지 경로(pack URI 방식)
        private Uri uriAngryImage = new Uri("pack://application:,,,/Assets/test3.jpg", UriKind.Absolute);
        private Uri uriHappyImage = new Uri("pack://application:,,,/Assets/test4.jpg", UriKind.Absolute);
        public MainWindow()
        {
            InitializeComponent();

            //1. Resource 초기 이미지 설정
            imgTest.Source = new BitmapImage(new Uri("Assets/코딩온 인스타그램.png", UriKind.Relative));
            /*
             * new Uri(...) - 이미지 파일의 경로를 Uri 객체로 만듬
             * 
             * UriKind.? - .? 해석하겠다는 의미
             * ㄴRelative: 실행 파일 기준 경로
             * ㄴAbsolute: 전체 경로 명시
             * ㄴRelativeOrAbsolute: 둘 중 맞는걸 자동 판별(거의 사용 x)
             * 
             * new BitmapImage(...) - Uri를 통해 실제 이미지 객체 생성
             */

            //2. Content 초기 이미지 설정
            imgTest2.Source = new BitmapImage(new Uri("Assets/코딩온 홈페이지.png", UriKind.Relative));

            //3-3. Pack URI 초기 이미지 설정
            imgDisplay.Source = new BitmapImage(uriAngryImage);
        }

        //1. Resource C# 버전
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            imgTest.Source = new BitmapImage(new Uri("Assets/코딩온 유튜브.png", UriKind.Relative));
        }
        //2. Content C# 버전
        private void Btn_Content_Click(object sender, RoutedEventArgs e)
        {
            //실행 디렉터리에 복사된 이미지 경로
            string path = "Assets/월페이퍼.png";

            //이미지 불러오기
            imgTest2.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        private void Btn_Change_Image_Click(object sender, RoutedEventArgs e)
        {
            //3-4. Pack URI 버튼 클릭시 이미지 전환
            imgDisplay.Source = new BitmapImage(isAngry ? uriAngryImage : uriHappyImage);

            //isAngry 값을 반전시킴(true -> false / false -> true)
            //-다음 버튼 클릭 시 반대 이미지가 나오도록 상태 전환
            isAngry = !isAngry;
        }
    }
}

#region 1. Image

/*
 * -WPF에서 사진, 아이콘, 일러스트 등 Bitmap 기반 이미지 리소스를 렌더링 할 때 사용하는 UI 컨트롤
 * -내부적으로는 System.Windows.Controls.Image 클래스
 * 
 * 이미지 파일 관리 - 폴더에 모아서 관리
 * -Assets: 가장 보편적이고 시각적인 리소스 포함하는 느낌
 * -Images: 이미지 전용 폴더로 직관적
 * 
 * 속성
 * -Source: 표시할 이미지 경로 or URI
 * -Stretch: 이미지 크기 조정 방식(None, Fill, Uniform(기본 값), UniformToFill)
 */

#endregion

//이미지 접근 방식

#region 1) Resource 방식

/*
 * 1) Resource 방식
 * -이미지 파일을 실행 프로그램(.exe)에 포함시켜 배포하는 방식
 * ㄴ 즉, 프로그램 내부에 이미지가 포함되어 있는 형태라 외부 파일을 따로 챙길 필요 x
 * -수정은 불가능하지만 정적인 리소스(아이콘, 배경, 버튼 등)에 매우 적합
 * 
 * 특징
 * -배포 간편
 * -경로 문제 x
 * -유지보수 용이
 * 
 * 방법
 * -솔루션 탐색기에서 이미지 추가
 * -추가한 이미지 선택 -> 속성
 * ㄴ빌드 작업(Build Action) => Resource로 설정
 * -출력 디렉토리에 복사: 필요 x
 * ㄴ실행 파일이 생성되는 폴더에 이 파일을 같이 복사할지 설정
 * ㄴ복사하지 않으면 프로그램이 실행될 때 해당 파일을 찾을 수 없음
 * 
 * -XAML 또는 C# 코드에서 Source="파일명"으로 간단하게 이미지 사용 가능
 * ㄴVS(visual studio) 프로젝트의 루트 기중 상대경로로 동작
 * 
 * 코드 작성
 * 1)XAML 버전
 * -이미지가 바뀌지 않을 때, 즉 고정된 화면에 정적인 이미지를 보여줄 때 사용
 * 
 * 2)C# 코드 버전
 * -동적으로 이미지를 제어할 때
 * 
 * 주의
 * -WPF에서는 Resource 파일 접근 시 Pack URI 방식 사용 권장
 * -XAML에서는 상대경로처럼 보여도 내부적으로 Pack URI로 해석
 */

#endregion

#region 2) Content 방식

/*
 * 2) Content 방식
 * -이미지 파일을 실행 파일(.exe)이 있는 폴더에 복사해 놓고, 거기서 직접 불러오는 방식
 * 
 * 특징
 * -실행 파일 외부에 따로 존재하는 이미지
 * -프로그램이 실행될 때 이미지 파일을 같이 복사해서 사용하는 구조
 * 
 * 방법
 * -이미지 추가
 * -추가한 이미지 선택 -> 속성
 * ㄴ빌드 작업(Build Action): Content
 * ㄴ출력 디렉토리에 복사: Copy if newer(권장)
 *  ㄴ그래야 실행폴더(bin/..)에 같이 복사됨
 *  
 *  Copy to Output Directory
 *  -Do not copy: 복사 x
 *  -Copy if newer: 새로 고칠때만 복사 (=원본 변화시 복사)
 *  -Copy always: 항상 복사
 */

#endregion

#region 3) Pack URI 방식

/*
 * 3) Pack URI 방식
 * -WPF에서 Resource 방식으로 등록된 이미지 파일을 정확하게 식별하고 로드할 수 있게 해주는 전용 URI 방식
 * -WPF의 스타일, 리소스, 외부 DLL 등 다양한 곳에서 이미지와 리소스를 참조할 때 필수로 사용
 * 
 * 특징
 * -Resource 방식 이미지에 대한 절대 경로 지정 가능
 * -외부 DLL에 포함된 리소스도 접근 가능
 * -UriKind.Absolute 와 함께 사용(필수)
 * 
 * 쓸때
 * -외부 라이브러리(DLL)에 포함된 리소스 접근할 때
 * -C# 코드에서 Resource 이미지에 대해 명확한 식별이 필요할 때
 * -프로젝트 구조가 복잡하거나 리소스 공유가 많을 때 안정적
 * 
 * Pack URI 문법 형식
 * -pack://application:,,,/[경로]
 * 
 * 방법
 * 1. 이미지 추가 -> Resources 폴더, assets 폴더 등
 * 2. 속성에서 Build Action -> Resource
 * 3. 출력 디렉토리에 복사: 필요 x
 * 4. pack URI 사용해 이미지 로드
 */

#endregion

#region 보충

/*
 * 정리
 * -앱 개발자가 미리 넣어두는 이미지 -> 빌드 시 포함되어 배포: Resource, Content
 * -앱 실행중 사용자의 입력으로 생긴 이미지 -> 외부 경로에 저장: 절대 경로(UriKind.Absolute)
 * 
 * Resource VS Content
 * Resource
 * -빌드 결과: 어셈블리 안에 내장
 * -경로 접근: pack://... URI 방식
 * -파일 존재 위치: 실행중에는 실제 파일 x(메모리상에만 존재)
 * -수정/삭제 불가(읽기 전용)
 * -대표 용도: 아이콘, UI 배경 이미지, 버튼 배경이미지 등 정적인 리소스
 * 
 * Content
 * -빌드 결과: 실행파일 옆에 복사
 * -경로 접근: 상대/절대 경로 방식
 * -파일 존재 위치: 실행 폴더에 파일 존재
 * -수정/삭제 가능
 * -대표 용도: 설명 이미지, 문서, 동영상 등 실제 파일이 필요할 때
 * ㄴ실행 중 수정 가능 -> 유저가 설정을 바꿀 때 (ex. 게임 데이터 저장)
 * ㄴ용량 이슈 / 관리 용이성
 *  ㄴResource: 실행 파일 크기 증가
 *  ㄴContent: 실행 파일이 가볍고 파일이 따로 존재 -> 메모리 사용 가벼워짐
 *  ㄴ유지 보수시 Content는 파일만 바꾸면 되어 유리
 *  
 * Build Action VS UriKind
 * -Resource, Content는 파일의 빌드 방식에 대한 설정
 * -UriKind는 해당 파일을 어떻게 접근할지에 대한 설정 방식
 * ㄴ둘은 직접적인 관련 x
 * 
 * Resource - Pack URI(pack://...) 사용 => UriKind.Absolute(항상)
 * Content - 상대/절대 경로 사용 => Relative or Absolute 사용
 * (외부 파일) - 물리 경로 or URL => 보통 Absolute 사용
 * 
 * 왜 Resource를 꼭 Pack URI로 사용해야 하는가
 * -WPF는 .exe 내부의 Resource 파일을 찾을 수 있도록 Pack URI라는 전용 주소 체계를 사용
 * 
 * 경로의 @는 언제 사용하는가
 * -주요 용도
 * ㄴ이스케이프 시퀀스 무시
 * 
 * ㄴ일반 문자열에서 \가 이스케이프 문자로 사용되어 \t(줄바꿈) \r(탭간격) 등 나타내는데
 *   파일 경로에서는 \가 경로 구분자로 사용되어 \\ 두번 입력해야하는 불편함 존재
 *   ㄴ@를 사용하면 \를 한번만 입력해도 됨
 *   =@가 붙은 문자열은 \를 이스케이프 문자로 해석하지 않고 문자 그대로 받아들임
 *   
 * ㄴ이스케이프 문자는 프로그래밍 언어나 텍스트 형식에서 특수한 의미를 가지는 문자를
 *   일반 문자처럼 취급, 특수 문자를 표현하기 위해 사용되는 문자
 * -보통 백슬래시(\)와 함께 사용되어 일련의 이스케이프 시퀀스를 만듬
 * 
 * ->즉, 문자열 내에서 특수문자를 표현하기 위해
 * ㄴ""가 문자열의 시작과 끝을 나타내듯이  
 * ㄴ\또한 출력 시 특별한 동작을 지시하기 위해 사용: \t, \r, \n
 * 
 * -C# 개발이 Windows 환경에 익숙하므로
 *  보통 탐색기나 프로그램에서 파일 경로를 복사
 *  ㄴ기본적으로 \로 된 경로가 제공
 * 
 * -이를 보통 그대로 코드에 넣기에 @를 붙이는 것이 빠르고 익숙한 방식
 */

#endregion