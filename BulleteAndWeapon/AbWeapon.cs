using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public abstract class AbWeapon : MonoBehaviour //武器模板
{
    protected int tankLv;
    public int TankLV { get => tankLv; set => tankLv = value; }

    //public int Mylv;
    //public abstract void SetMylv(int lv);(test)

    [SerializeField]private Button btn;

    public GameObject Bullete;//子彈模板

    [SerializeField]private Animator anim;
    [SerializeField] protected Transform parentTrans;
    //[SerializeField] protected WeaponAttr attr;
    private bool Iscold =true;

    protected float coldTime=1f;
    public float ColdTime { get => coldTime; set => coldTime = value; }

    [SerializeField] float Speed;

    private bool isActivate = true;
    public bool IsActivate { get => isActivate; set => isActivate = value; }

    protected float Dam;
    public float permeability;

    private bool canclick = true;
    public bool Canclick { get => canclick; set => canclick = value; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsActivate)
        {
            if (collision.tag == "Enemy" || collision.tag == "Player")
            {
                if (Iscold)
                {
                    Shoot(collision.transform);
                    Iscold = false;
                    StartCoroutine(Wait(coldTime));
                }
            }
        }
    }

    /*// recordRange
    string datas;
    public class RangeExp
    {
        public RangeExp(string n, Vector3 v3) { this.name = n;this.v3 = v3; }
        public string name;
        public Vector3 v3;
    }
    public class TheDatas
    {
        public TheDatas(ArrayList d) { thedata = d; }
        public ArrayList thedata;
    }
    public ArrayList tmpdata ;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Enemy")
        {
            RangeExp rangeExp = new RangeExp("In" + $"{collision.gameObject.name}", collision.transform.position);
            string Data = JsonUtility.ToJson(rangeExp);
            datas+=(Data)+",";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag is "Enemy")
        {
            RangeExp rangeExp = new RangeExp("Exit"+$"{collision.gameObject.name}", collision.transform.position);
            string Data = JsonUtility.ToJson(rangeExp);
            datas += (Data)+",";
        }
    }
    //
    void saveToJson()
    {
        Debug.Log("取數據 : "+datas);
        //File.WriteAllText("/Users/mac/Desktop/GameRelevant" + "save.json","{\"DATA\":["+datas+"]}");
    }
    //*/

    private void Shoot(Transform target)
    {
        Vector2 vector = TargetPos(target);
        anim.SetBool("Shoot",true);
        parentTrans.up = vector;
        CreateBullete(vector, Dam, permeability);
        //GameObject bullete= Instantiate(Bullete,transform.position,Quaternion.identity);
        //bullete.GetComponent<BulleteOne>().Direction = vector;
        //bullete.GetComponent<BulleteOne>().Shooted =true;

        //GameObject bullete2 = Instantiate(Bullete, new Vector2(transform.position.x, transform.position.y + 20f), Quaternion.identity);
        //bullete2.GetComponent<BulleteOne>().Direction = vector;
        //bullete2.GetComponent<BulleteOne>().Shooted = true;
    }

    protected virtual Vector2 TargetPos(Transform target)
    {
        return target.position - transform.position;
    }

    protected abstract void CreateBullete(Vector2 vector,float dam,float per);
    

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Iscold = true;
        anim.SetBool("Shoot", false);//目前先在這裡false之後用blendtree再改
    }

    private void Start()
    {
        //Debug.Log("Start");
        //等級跟uidrag
        //tankLv = GameObject.FindGameObjectWithTag("UI").GetComponentInChildren<UIDrag>().FactoryLv;
        DontDestroyOnLoad(GetComponentInParent<Rigidbody2D>());
        btn.onClick.AddListener(ToUpdate);
    }

    private void ToUpdate()
    {
        UpgradeSys.instance.Canvas.SetActive(true);
        UpgradeSys.instance.clickedTank = this;
        
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    Debug.Log("save");
        //    saveToJson();
        //}
    }
}
