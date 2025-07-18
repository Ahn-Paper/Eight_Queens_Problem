Unity를 이용해 구현한 '여덟 퀸 문제' 퍼즐입니다.

<br/>

#### 여덟 퀸 문제(Eight Queens Problem) : 
8x8 체스판 위에 퀸 8개를 서로 공격하지 못하게 배치하는 퍼즐

<br/>

---

<br/>

### 메인화면

![메인](https://github.com/user-attachments/assets/f4e66916-51fd-4e6d-b891-a2cb21f9192a)

체스판과 퀸 개수 표기란, 버튼 3개로 UI를 구성했습니다.

마우스로 체스판을 누를 시, 해당 위치에 퀸을 생성합니다.

<br/>
<br/>

### 퀸 생성

![8개 제한](https://github.com/user-attachments/assets/68fe8595-9177-4283-a6fe-8f661648ea0a)

퀸은 8개까지만 생성할 수 있으며, 8개를 초과하여 생성하려고 하면 더 이상 놓을 수 없다는 내용의 토스트 메세지가 출력됩니다.

또한 퀸 개수가 8개가 되면, 퀸 개수 표기란이 붉은색으로 강조됩니다.

<br/>
<br/>

### 초기화 버튼

![초기화](https://github.com/user-attachments/assets/93c90b39-90bc-4a9a-bb89-0c4d9c2111e0)

[초기화] 버튼을 누를 시, 토스트 메세지를 출력하며 체스판 위의 퀸을 전부 제거합니다.

<br/>
<br/>

### 경로 확인 버튼

![퀸 경로](https://github.com/user-attachments/assets/aca3d3a7-7e94-4687-a45d-fe4a87ec6eff)

[경로 확인] 버튼을 누를 시, 퀸이 놓인 발판의 색상이 변경됩니다.

안전한(공격받지 않는) 위치의 퀸은 초록색으로 표기되고, 반대로 공격받는 위치의 퀸은 공격받는 경로와 함께 붉은색으로 표기됩니다.

<br/>
<br/>

### 정답 제출 버튼

![퀸 부족](https://github.com/user-attachments/assets/dd26b80b-d072-4eac-9350-e65b3576cf21)

[정답 제출] 버튼을 누를 시, 먼저 퀸의 개수를 확인합니다.

퀸의 개수가 8개가 되지 않을 경우, 채점을 하지 않고 퀸을 더 생성해달라는 토스트 메세지가 출력됩니다.

<br/>
<br/>

![정답 제출](https://github.com/user-attachments/assets/06bd34f7-ea60-471a-a248-06a82f2c1542)
![오답](https://github.com/user-attachments/assets/cb4b7847-7d52-41de-8c5d-5740c4df4d0a)

반면 퀸 개수가 8개일 경우, 정상적으로 채점을 시작합니다.

채점 시 사용자가 직접 정답 여부를 확인할 수 있도록 [경로 확인] 버튼이 활성화됩니다.

이후 정답이라면 패널을 통해 '클리어!' 문구를, 오답이면 '틀렸습니다.' 문구를 출력합니다.

<br/>




