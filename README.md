# unity-basic



3D

01 - CharacterController 기반의 오브젝트 이동

- 3차원 게임에서 사람 형태의 캐릭터 움직임과 관련된 제어를 위해 사용
- 캡슐(Capsule) 형태의 충돌 범위가 포함되어 있다.
- Slope Limit : 올라갈 수 있는 경사 한계 각
- Step Offset : 설정 값보다 낮은 높이의 계단(그 외 오브젝트)를 오를 수 있다.
- Center : Capsule 충돌 범위의 중심점
- Radius : Capsule 충돌 범위의 반지름 (x, z)
- Height : Capsule 충돌 범위의 높이 (y)

3D object에 색상을 부여하는 법 - Material을 만들어 색상과 이미지를 설정하고 Object에 등록

CharacterController.Move(Vector3 motion);

매개변수로 이동방향, 속도 Time.deltaTime 등의 세부적인 이동 방법을 설정하면 이동을 수행한다.

CharacterController.SimpleMove(Vector3 speed);

매개변수로 3 방향의 이동속도(=속력)를 넣어 호출하면 이동을 수행한다.

CharaterController.isGrounded

발 위치의 충돌을 체크해 충돌이 되면 true, 충돌이 되지 않으면 false 값을 나타내는 변수

Input.GetAxis("Mouse X") : 마우스를 좌/우로 움직였을 때

왼쪽으로 이동 : -1 / 대기 :  0 / 오른쪽으로 이동 : 1

Input.GetAxis("Mouse Y") : 마우스를 위/아래로 움직였을 때

아래로 이동 -1 / 대기 : 0 / 위로 이동 : 1

------

02 - Navigation Mesh 기초

- NavMeshAgent : 네비게이션 메싲 정보를 바탕으로 이동하는 오브젝트

- OffMeshLink : 연결이 끊어져 있는 절벽, 낭떠러지, 사다리 등을 이동 가능하게 설정

- NavMeshObstacle : 이동하는 장애물의 네비게이션 메시 정보를 실시간으로 설정

- Navigation Mesh :  게임월드에 이동 가능, 이동 불가능 등의 경로를 데이터로 저장



Naviagtion View - Agents

네비게이션 메시 정보를 바탕으로 움직이는 에이전트에 대한 설정 (NavMeshAgent 컴포넌트)

AgentType : 에이전트 속성 "+"로 새로운 에이전트 속성을 추가할  수 있다.

Agent 정보

- Name : Agent Type에 보여지는 이름

- Radius : 에이전트의 반지름

- Height : 에이전트의 높이(키)

- Step Height : 오르내릴 수 있는 계단의 높이

- Max Slope : 올라갈 수 있는 경사 각도



Navigation View - Areas

네비게이션 메시로 사용되는 오브젝트들의 구역설정

- Name : 구역 이름으로 기본으로 Walkable(이동 가능), Not Walkable(이동 불가능), Jump(뛰기)가 제공되고, User 3부터 원하는 구역을 추가로 설정할 수 있다.

- Cost : 구역과 함께 등록, 이동하는데 소요되는 비용(1이상) 경로를 탐색할 때 Cost 정보를 기준으로 최단거리를 찾게 된다. Cost가 2인 Jump는 Cost가 1인 Walkalbe을 지나갈 때 보다 2배의 시간이 걸린다는 뜻으로 사용된다.(실제 오브젝트의 물리적인 이동 속도가 느려지는 것이 아닌 경로를 계산할 때 활용된다.)



Naviagtion View - Bake

네비게이션 메시 데이터를 생성

Baked Agent Size

- Agent Radius : 에이전트가 지나갈 수 있는 반지름

- Agent Height : 에이전트가 아래로 지나갈 수 있는 높이

- Max Slope : 에이전트가 올라갈 수 있는 경사 각도

- Step Height: 에이전트가 오르내릴 수 있는 계단의 높이

Generated Off Mesh Links

오프 메시 링크는 올라 가기 힘든 언덕, 사다리, 절벽 등을 연결해서 이동 가능하게 만드는 옵션이다.

- Drop Height: 이동 할 수 있는 절벽 아래의 높이

- Jump Distance : 뛰어서 넘을 수 있는 절벽 거리

"Bake" 버튼

Navigation에 설정된 옵션들을 바탕으로 네비게이션 정보를 데이터로 굽는다.



Navigation View - Object

현재 씬(Scene)에 있는 오브젝트 설정 (하나 or 다수)

Scene Filter:

현재 씬에서 원하는 오브젝트만 선택해서 볼 수 있다.

(Mesh Renderer 컴포넌트, Terrain 컴포넌트 선택 가능)

선택된 오브젝트

Navigation Static: 네비게이션 메시로 사용할지 설정

Generate OffMeshLinks : 자동으로 Off Mesh를 생성할지 설정

Navigation Area: 해당 오브젝트의 구역 설정

(설정되는 구역에 따라 해당 오브젝트의 Cost가 설정된다)



게임 오브젝의 "Navigation Static" 설정 방법

원하는 게임 오브젝트를 선택한 후

방법 1. Inspector View의 Static - Navigation Static 선택

방법 2. Navigation View의 Object 탭에 있는 "Navigation Static" 변수 체크



SceneView를 보면 하늘색으로 표시되는 부분이 이동가능한 부분이다.

(Navigation View가 활성화 되어 있어야 Navigation Mesh가 출력된다)



NavMeshAgent 컴포넌트

네비게이션 메시 정보를 기반으로 하는 에이전트

에이전트 이동 (Steering)

- Speed : 이동속도
- Augular Speed : 방향을 바꿀때의 회전속도
- Acceleration : 가속도 (정지 상태에서 이동속가 될 때까지 적용)
- Stopping Distance : 목적지가 이 값까지 가까워지면 이동을 멈추게 된다.
- Auto Braking : 목적지에 가까워지면 멈추는 기능 (목적지에 도착해도 에이전트를 멈추지 않을 때 사용), (여러 목적지를 계속 탐색하는 순찰 오브젝트에 주로 사용)

장애물 회피 (Obstacle Avoidance)

- Radius : 장애물을 회피할 때 에이전트의 반지름
- Height : 에이전트의 높이
- Ouality : 장애물과 충돌 수준 (None이면 뚫고 지나간다)
- Priority : 장애물과 충돌했을 때의 우선순위 (낮을 수록 높다) (이동중인 두 에이전트의 모든 조건이 동일 할 때 Priority가 낮은 에이전트가 더 우선권을 가지고 경로를 탐색하게 된다)

경로 탐색 (Path Finding)

- Auto Traverse Off Mesh Link : 오프 메시 링크가 있을 경우 자동으로 탐색해서 찾아갈지 설정
- Auto Repath : 이동 중에 경로 탐색을 다시 할지 설정 (true : 이동 중에 장애물 등으로 막혔을 때 자동으로 재 계산)
- Area Mask : 해당 에이전트의 이동 가능한 구역 지정
