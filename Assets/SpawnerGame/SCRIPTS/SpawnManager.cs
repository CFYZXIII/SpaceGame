using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private AudioManager manager;
    [SerializeField] private AudioManager manager2;
    [SerializeField] private DropSpawner spawnerLeft;
    [SerializeField] private DropSpawner spawnerRight;
    [SerializeField] private HeltBar heltBar;
   // [SerializeField] private Joystick j1, j2;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private GameObject numbers;
    [SerializeField] private int waveCount;
    [SerializeField] private Difficult difficult;
    SpriteRenderer numberRenderer;
    public bool evade;
    int spirale;


    

    
    public bool swap;
    bool isGame;


    public static int fail = 0;
    int STATUS = 0;
    public int waveState = 0;
    float timeToSpawn = 0;
    float refreshTime = 0;
    
    
    private void Awake()
    {
       
        fail = 0;
    }
    void Start()
    {
        numberRenderer = numbers.GetComponent<SpriteRenderer>();

        spawnerLeft.Event += Spawner_Event;
        spawnerRight.Event += Spawner_Event;
        //StartCoroutine(Spawn()); 
        
    }

    
    private void Spawner_Event(object sender, MyEvent e)
    {
        fail++;
        manager2.Play();
        heltBar.HealthReduse();
        if (heltBar.objects.Count == 0)
        {
            spawnerLeft.Event -= Spawner_Event;
            spawnerRight.Event -= Spawner_Event;
            isGame = false;
            spawnerLeft.p.myControl.locked = 0;
            spawnerRight.p.myControl.locked = 0;
           
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver() 
    { 
       yield return new WaitForSeconds(1.5f);
        
        SceneManager.LoadScene(2);

             
    }
    // Update is called once per frame

    public void StartCoroutine() 
    {
        StartCoroutine(Spawn());
        manager.Play();
    }
    void FixedUpdate()
    {

        if (spawnerLeft.p.myControl.TotalSwap)
            spawnerLeft.p.myControl.TotalSwap = spawnerLeft.p.myControl.Swap(spawnerRight.p.myControl);
        spawn(1.5f,0.5f);

        if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);
            
    }

    IEnumerator Spawn() 
    {
        for (int i = 0; i < 4; i++)
        {
            numberRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(1f);
        }
        numbers.SetActive(false);
        isGame = true;   
        
    }

  

    void spawn(float t_toSpawn, float t_torefresh) 
    {
        if (isGame)
        {
           spawnerLeft.p.myControl.locked = 1;
           spawnerRight.p.myControl.locked = 1;
            if (spawnerLeft.isspawn && spawnerRight.isspawn)
            {
                if (waveState == waveCount)
                {
                    if (STATUS == 0)
                    {
                        STATUS = Random.Range(1, 9);
                        difficult.SetObj(STATUS-1);
                    }
                    refreshTime += Time.deltaTime;
                    if (refreshTime >= t_torefresh)
                    {
                        waveState = 0;
                        refreshTime = 0;




                        
                            
                            switch (STATUS)
                            {
                                case 1:
                                    Debug.Log("Задачи левого меняются");
                                    spawnerLeft.evade = !spawnerLeft.evade;
                                   
                                    break;
                                case 2:
                                    Debug.Log("Задачи правого меняются");
                               
                                spawnerRight.evade = !spawnerRight.evade;
                                    break;
                                case 3:
                                    Debug.Log("Управление левым - инверсия");

                                //spawnerLeft.inverse *= -1;
                                spawnerLeft.p.myControl.SideSwap = true;
                                    break;
                                case 4:
                                    Debug.Log("Управление правым - инверсия");

                              spawnerRight.p.myControl.SideSwap = true;
                                break;
                                case 5:
                                    Debug.Log("Джойстики меняются");

                                spawnerLeft.p.myControl.TotalSwap = true;
                                    break;
                                case 6:
                                    Debug.Log("Спираль левая"); // может получиться как против, так и по часовой
                                
                                if (spawnerLeft.spirale == 0)
                                        spawnerLeft.spirale = (int)Mathf.Pow(-1, Random.Range(0, 2));
                                    else
                                        spawnerLeft.spirale = 0;
                                    break;
                                case 7:
                               
                                Debug.Log("Спираль правая"); // может получиться как против, так и по часовой
                                    if (spawnerRight.spirale == 0)
                                        spawnerRight.spirale = (int)Mathf.Pow(-1, Random.Range(0, 2));
                                    else
                                        spawnerRight.spirale = 0;
                                    break;
                            case 8:

                                Debug.Log("ПЕРЕВЕРНУЛОСЬ"); // может получиться как против, так и по часовой                               
                                Camera.main.transform.Rotate(0, 0, 180);
                                break;
                            default: break;
                                
                            }
                        {
                            STATUS = 0;
                            
                        }
                            
                        






                    }
                }
                if (refreshTime == 0)
                    timeToSpawn += Time.deltaTime;
                if (timeToSpawn >= t_toSpawn)
                {
                    difficult.ResetObj();
                    spawnerLeft.spawn();
                    spawnerRight.spawn();
                    waveState++;
                    timeToSpawn = 0;
                }
            }
        }
    }

    public void ReduseHealh()
    {
        fail++;
    }
}
