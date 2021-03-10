# StudyDesktopApp
C# 데스크톱 앱 개발 학습 리포지토리   

---

# 2021.03.09 Day1   
#### 폼 생선 전 기본 형태   
```
form1.cs -> frmMain.cs   
startposition 잡아주기   
icon 생성 
전체 폼 틀을 잡아주기   
```

### Practice App Template
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/PraticeApp.png" width="600px" height="250px" title="연습앱" alt="연습앱"/>   

### Label Test App   
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/LabelTestApp.png" width="600px" height="250px" title="라벨 앱" alt="라벨 앱"/>   

### CheckBox Test App   
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/CheckBoxWinApp.png" width="600px" height="250px" title="체크박스 앱" alt="체크박스 앱"/>   

### Masked Test App
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/MaskedTestApp.png" width="600px" height="250px" title="사원정보 앱" alt="사원정보 앱"/>   

### Radio Test App
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/RadioWinApp.png" width="600px" height="250px" title="라디오 버튼 앱" alt="라디오 버튼 앱"/>   

### Flag Test App
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/FlagWinApp.png" width="600px" height="250px" title="플래그 앱" alt="플래그 앱"/>   

### Login Test App
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/LoginApp.png" width="600px" height="250px" title="로그인 앱" alt="로그인 앱"/>   

### ColorChange Test App
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/ColorChangerApp.png" width="600px" height="250px" title="색 변화 앱" alt="색 변화 앱"/>   

---   

# 2021.03.10 Day2   

### ListBox Test App   
```
** listbox 넣는 방법 **   
1. 디자인 타입 : 폼에서 바로 디자인   
2. 런 타입 : 코딩 후 실행했을 때 동작하는 방식   

* 리스트 박스 넣는 방법 
  : 가장 기본적인 코딩
private void FrmMain_Load(object sender, EventArgs e)
        {
            //살기 좋은 도시 초기화 , 가장 기본적인 리스트박스 추가
            LsbGoodCity.Items.Add("오스트리아,빈");
            LsbGoodCity.Items.Add("호주, 맬버른");
            LsbGoodCity.Items.Add("일본,오사카");
            LsbGoodCity.Items.Add("캐나다,캘거리");
            LsbGoodCity.Items.Add("호주, 시드니");
            LsbGoodCity.Items.Add("캐나다, 밴쿠버");
            LsbGoodCity.Items.Add("일본, 도쿄");
            LsbGoodCity.Items.Add("캐나다, 토론토");
            LsbGoodCity.Items.Add("덴마크, 코펜하겐");
            LsbGoodCity.Items.Add("호주, 애들레이드");

            List<string> lstCountry = new List<string>() { 
                "미국","러시아","중국","독일","프랑스","일본","이스라엘",
                "사우디아라비아","UAE","한국","영국","스웨덴"
            };
            LsbHappyCountry.DataSource = lstCountry;   
            
 ```
      
<img src="https://github.com/hyojin-park24/StudyDesktopApp/blob/main/WinformApp/Media/ListBoxWinApp3.png" width="600px" height="250px" title="리스트 박스 앱" alt="리스트  앱"/>   

##### 잠깐의 이론! 
```
**Tostring : Object값이다
**Sender : Object값이다
			이벤트는,
			Object의 Class 로 박싱해준다 즉, 초기화 원래상태로 돌려준다. 
			모든 컨트롤이 이벤트에 있다.
			하나로 통일해서 델리게이트 (대리자) 해야한다.
			Ex) private void LsbHappyCountry_SelectedIndexChanged(object sender, EventArgs e)
			이벤트에 대한 이름을 쓰고, 
			앞에는 이벤트보내준 객체를 설명, 뒤에는 이벤트 속성을 설명(아규먼트)
			델리게이트를 선언 후에 객체가 다양하기 때문에 합친 값이 Object값이다.
			그 다음 object로 박싱한 다음 사용하기 위해서 unboxing을 해야한다. 
			∴ 값을 돌려주는 초기화를 시켜준다 
			1. 형변환 
			- 값 타입 : ()
			- 참조 타입 : as     
```  





