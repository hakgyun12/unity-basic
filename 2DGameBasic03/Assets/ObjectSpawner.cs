using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private int objectSpawnCount = 30;
    [SerializeField]
    //private GameObject boxPrefab;
    private GameObject[] prefabArray;
    [SerializeField]
    private Transform[] spawnPointArray;
    private int currentObjectCount = 0;
    private float objectSpawnTime = 0.0f;

    private void Update()
    {
        // objectSpawnCount 개수만큼만 생성하고 더이상 생성하지 않도록 하기 위해 설정
        if (currentObjectCount + 1 > objectSpawnCount)
        {
            return;
        }

        // 원하는 시간마다 오브젝트를 생성하기 위한 시간 변수 연ㅅ나
        objectSpawnTime += Time.deltaTime;

        // 0.5초에 한번씩 실행
        if (objectSpawnTime >= 0.5f)
        {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

            //spawnIndex가 0인 오브젝트가 왼쪽에 있기 때문에 오른쪽을 이동
            //spawnIndex가 1인 오브젝트가 오른쪽에 있기 때문에 왼쪽으로 이동
            Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D>().Setup(moveDirection);

            currentObjectCount++; // 현재 생성된 오브젝트의 개수를 1 증가시킨다.
            objectSpawnTime = 0.0f; // 시간을 0으로 초기화해야 다시 0.5초를 계산할 수 있다.
        }
    }

    //private void Awake()
    //{
        // 1. Instantiate(원본오프젝트)
        //Instantiate(boxPrefab);

        // 2. Instantiate(원본오브젝트, 위치, 회전);
        //Instantiate(boxPrefab, new Vector3(3, 3, 0), Quaternion.identity);
        //Instantiate(boxPrefab, new Vector3(-1, -2, 0), Quaternion.identity);

        // 3. 회전값 설정
        //Quaternion rotation = Quaternion.Euler(0, 0, 45);
        //Instantiate(boxPrefab, new Vector3(2, 1, 0), rotation);

        // 4. 방금 생성된 복제 정보 받아서 설정하기
        //GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);

        // 방금 생성된 게임 오브젝트의 이름 변경
        //clone.name = "Box001";
        // 방금 생성된 게임 오브젝트의 색상 변경
        //clone.GetComponent<SpriteRenderer>().color = Color.black;
        // 방금 생성된 게임 오브젝트의 위치 변경
        //clone.transform.position = new Vector3(2, 1, 0);
        // 크기 변경
        //clone.transform.localScale = new Vector3(3, 2, 1);

        // 외부 반복문 (격자의 y축 계산용으로 활용됨)
        //for(int y=0; y<10; ++y)
        //{   
        //    // 내부 반복문 (격자의 x축 계산용으로 활용됨)
        //    for(int x=0; x<10; ++x)
        //    {
        //        if ( x + y == 4 || x - y == 5 || y - x == 5 || x + y == 14)
        //        {
        //            continue;
        //        }
        //        Vector3 position = new Vector3(-4.5f + x, 4.5f - y, 0);

        //        Instantiate(boxPrefab, position, Quaternion.identity);
        //    }
        //}

        //for(int i=0; i< 10; ++i)
        //{
        //    //첫번째 매개변수부터 두번째 매개변수까지 정수중에서 임의의 숫자를 index에 저장
        //    int index = Random.Range(0, prefabArray.Length);
        //    Vector3 position = new Vector3(-4.5f + i, 0, 0);

        //    Instantiate(prefabArray[index], position, Quaternion.identity);


        //Spawnpoint에서 오브젝트 생성
        //for(int i=0; i<objectSpawnCount; ++i)
        //{
        //    int prefabIndex = Random.Range(0, prefabArray.Length);
        //    int spawnIndex = Random.Range(0, spawnPointArray.Length);

        //    Vector3 position = spawnPointArray[spawnIndex].position;
        //    GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

        //    Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
        //    clone.GetComponent<Movement2D>().Setup(moveDirection);
        //}
       
    //}
}
