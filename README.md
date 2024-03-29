## 목차
- [개요](#개요)
- [게임 플레이 화면](#게임-플레이-화면)
- [게임 플레이 방식](#게임-플레이-방식)

<br><br>

## 개요
- 게임 장르 : 플랫포머, 러닝 액션 게임
- 개발 엔진 및 언어 : Unity, C#
- 개발 기간 : 2024.02.22-2024.03.05
- 개발 시간 : 21시간

<br><br>

## 게임 플레이 화면
|게임 시작 화면|게임 종료 화면|
|-|-|
|<img src="./img/StartScene.png">|<img src="./img/EndScene.png">|

|레벨 1|레벨 2|
|-|-|
|<img src="./img/Level1.png">|<img src="./img/Level2.png">|

<br><br>

## 게임 플레이 방식
||좌|우|점프|공격|무기 변경(Level 2 한정)|나가기|
|:-:|:-:|:-:|:-:|:-:|:-:|:-:|
|키보드|A|D|SPACE Bar|마우스 좌클릭|C|ESC|
|방향키|&larr;|&rarr;|-|-|-|-|

<br>

- 레벨 1
    - 개요 : 플랫포머 형식의 게임입니다. 플레이어와 적대 관계에 있는 몬스터가 존재하고, 플레이어가 가까이 가면 플레이어를 공격합니다. 플레이어는 몬스터를 피하거나 죽이면서 다음 레벨로 가기 위한 탈출구를 찾아야 합니다.
    - 점수 획득 조건 : 몬스터 처치 및 코인 획득 시 스코어가 오릅니다.
- 레벨 2
    - 개요 : 러닝 액션 형식의 게임입니다. 상하로 움직이며 불꽃을 쏘는 적을 피하면서 해당 적의 hp가 닳을 때까지 공격해야 합니다. 적을 처치했을 경우에 게임이 끝납니다.
    - 점수 획득 조건 : 적 공격 시 스코어가 오릅니다. 근접 공격 시 원거리 공격보다 더 높은 스코어를 얻을 수 있습니다.

- 승리 조건 : 쫓아오는 적을 처치하고 탈출하는 것입니다.
