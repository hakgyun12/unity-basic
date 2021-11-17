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
        // objectSpawnCount ������ŭ�� �����ϰ� ���̻� �������� �ʵ��� �ϱ� ���� ����
        if (currentObjectCount + 1 > objectSpawnCount)
        {
            return;
        }

        // ���ϴ� �ð����� ������Ʈ�� �����ϱ� ���� �ð� ���� ������
        objectSpawnTime += Time.deltaTime;

        // 0.5�ʿ� �ѹ��� ����
        if (objectSpawnTime >= 0.5f)
        {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

            //spawnIndex�� 0�� ������Ʈ�� ���ʿ� �ֱ� ������ �������� �̵�
            //spawnIndex�� 1�� ������Ʈ�� �����ʿ� �ֱ� ������ �������� �̵�
            Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D>().Setup(moveDirection);

            currentObjectCount++; // ���� ������ ������Ʈ�� ������ 1 ������Ų��.
            objectSpawnTime = 0.0f; // �ð��� 0���� �ʱ�ȭ�ؾ� �ٽ� 0.5�ʸ� ����� �� �ִ�.
        }
    }

    //private void Awake()
    //{
        // 1. Instantiate(����������Ʈ)
        //Instantiate(boxPrefab);

        // 2. Instantiate(����������Ʈ, ��ġ, ȸ��);
        //Instantiate(boxPrefab, new Vector3(3, 3, 0), Quaternion.identity);
        //Instantiate(boxPrefab, new Vector3(-1, -2, 0), Quaternion.identity);

        // 3. ȸ���� ����
        //Quaternion rotation = Quaternion.Euler(0, 0, 45);
        //Instantiate(boxPrefab, new Vector3(2, 1, 0), rotation);

        // 4. ��� ������ ���� ���� �޾Ƽ� �����ϱ�
        //GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);

        // ��� ������ ���� ������Ʈ�� �̸� ����
        //clone.name = "Box001";
        // ��� ������ ���� ������Ʈ�� ���� ����
        //clone.GetComponent<SpriteRenderer>().color = Color.black;
        // ��� ������ ���� ������Ʈ�� ��ġ ����
        //clone.transform.position = new Vector3(2, 1, 0);
        // ũ�� ����
        //clone.transform.localScale = new Vector3(3, 2, 1);

        // �ܺ� �ݺ��� (������ y�� �������� Ȱ���)
        //for(int y=0; y<10; ++y)
        //{   
        //    // ���� �ݺ��� (������ x�� �������� Ȱ���)
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
        //    //ù��° �Ű��������� �ι�° �Ű��������� �����߿��� ������ ���ڸ� index�� ����
        //    int index = Random.Range(0, prefabArray.Length);
        //    Vector3 position = new Vector3(-4.5f + i, 0, 0);

        //    Instantiate(prefabArray[index], position, Quaternion.identity);


        //Spawnpoint���� ������Ʈ ����
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
