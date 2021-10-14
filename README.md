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
