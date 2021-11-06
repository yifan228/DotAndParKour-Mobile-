using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDrag : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler //生成塔的程式也寫在這裡(onEndDrag)
{
    public int FactoryLv;
    
    [SerializeField] Canvas canvas;
    [HideInInspector]public CanvasGroup canvasGroup;

    private Vector2 tmpPos;
    public Vector2 Tm { get => tmpPos; set => tmpPos = value; }

    //private Vector2 pos;
    //public Vector2 Pos { get => pos; set => pos = value; }

    public bool canPlace;
    public bool inUI;

    Vector2 InitialVectwo;

    [Header("Tower")]
    public GameObject towerTank;
    //擲骰子，得到不同稀有度的塔
    //[SerializeField] GameObject tower2;

    private GameObject MountingSlotSys;

    [SerializeField]private GameObject goalProjectileImage;
    private GameObject goalprojectile;

    //生成隨機基數，增加隨機性
    public int DetCreateTowerNum;
    public int CreateTowerRandNum()
    {
        int num = Random.Range(1, 100);
        return num;//這裡可能要加上一些算法，例如運氣值、等級之類的
    }
    //public int CreateTowerRandNum()
    //{
    //    int num = Random.Range(1, 100);
    //    return num;//這裡可能要加上一些算法，例如運氣值、等級之類的
    //}
    private void Start()
    {
        canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        MountingSlotSys = GameObject.Find("CreateWeaponMountingSlot");
        DetCreateTowerNum = CreateTowerRandNum();
        if (DetCreateTowerNum >= 50)
        {
            //setUIImage
        }
        else if (DetCreateTowerNum < 50)
        {
            GetComponent<Image>().color = Color.green;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        InitialVectwo = transform.position;       
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Vector2 ancorpos;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out ancorpos); ;
        //this.GetComponent<RectTransform>().anchoredPosition = ancorpos;
        //(還沒研究canvas的screen-space camera 模式)

        //tmpPos = (Vector2)eventData.pointerCurrentRaycast.worldPosition;不知為何，出來的直會有點偏差

        this.GetComponent<RectTransform>().anchoredPosition += eventData.delta/canvas.scaleFactor;
        tmpPos = (Vector2)Camera.main.ScreenToWorldPoint(eventData.pointerCurrentRaycast.screenPosition);
        //RaycastHit2D[] hits = Physics2D.CircleCastAll(tmpPos, 0.1f,Vector2.zero);
       
        //if (hits==null)
        //{
        //    canPlace = true;
        //    canvasGroup.alpha = 1;
        //    return;
        //}
        
        //foreach (RaycastHit2D hit in hits)
        //{
        //    if (hit.collider.tag != "CantPlaceRange")
        //    {
        //        canPlace = true;
        //        canvasGroup.alpha = 1;
        //    }
        //    else
        //    {
        //        canPlace = false;
        //        canvasGroup.alpha = 0.5f;
        //        break;
        //    }
        //}
        if (inUI)
        {
            canPlace = false;
            canvasGroup.alpha = 1f;
            if (goalprojectile != null)
            {
                goalprojectile.SetActive(false);
            }
        }
        else
        {
            if (goalprojectile == null)
            {
                goalprojectile = Instantiate(goalProjectileImage, new Vector3(tmpPos.x, tmpPos.y, 0f), Quaternion.identity);
                goalprojectile.GetComponent<GoalProjectile>().uiDrag = this;
                //prefab 的資訊無法取得，不能這樣寫 goalprojectile.GetComponent<GoalProjectile>().range.transform.localScale = towerTank.transform.localScale/0.5f*GetComponentInChildren<AbWeapon>().GetComponent<CircleCollider2D>().radius;
            }
            else
            {
                goalprojectile.SetActive(true);
            }

            canPlace = true ;
            canvasGroup.alpha = 0;
        }
        if (goalprojectile != null&&goalprojectile.activeInHierarchy)
        {
            goalprojectile.transform.position = tmpPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (canPlace)
        {
            determineWhatKindOfTower(DetCreateTowerNum);
            //setTower;
            MountingSlotSys.GetComponent<CreateWeaponSys>().Remove(gameObject);
            Destroy(gameObject);
            Destroy(goalprojectile);
        }
        else
        {
            transform.position = InitialVectwo;
            if (goalprojectile !=null)
                goalprojectile.SetActive(false);
            canvasGroup.alpha = 1f;
        }
    }


    //武器實作towertank
    void determineWhatKindOfTower(int num)
    {
        if (num >= 50)
        {
            GameObject obj = Instantiate(towerTank, tmpPos, Quaternion.identity);
            obj.GetComponentInChildren<AbWeapon>().TankLV = FactoryLv+1;
        }
        else if (num < 50)
        {
            GameObject obj = Instantiate(towerTank, tmpPos, Quaternion.identity);
            obj.GetComponentInChildren<AbWeapon>().TankLV = FactoryLv;

            //tower2.GetComponentInChildren<AbWeapon>().Mylv = this.Lv;
            //tower2.GetComponentInChildren<AbWeapon>().GMLv = Lv;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        tmpPos= ((Vector2)Camera.main.ScreenToWorldPoint(eventData.pointerPressRaycast.screenPosition));
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.tag is "CantPlaceRange")
        {
            canPlace = false;
            canvasGroup.alpha = 1f;
        }
    }

 

   
}
