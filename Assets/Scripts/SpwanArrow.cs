using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanArrow : MonoBehaviour
{
    bool isArrowAvaialble = false;
    float pullBowForce;
    
    public int arrowCount;
    [SerializeField] GameObject arrowPrefab;
     GameObject newArrow;
    [SerializeField] GameObject bowPrefab;
    [SerializeField] int pullBowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GenerateArrow();
    }

    // Update is called once per frame
    void Update()
    {
      ReadyForShootArrow();

    }

    void GenerateArrow()
    {
        if (arrowCount > 0)
        {
            isArrowAvaialble = true;
            newArrow = GameObject.Instantiate(arrowPrefab, transform.position, transform.rotation);
            newArrow.transform.SetParent(transform, true);
            transform.localScale = transform.localScale + new Vector3(1, 1, 1);
        }
    }

    void ReadyForShootArrow()
    {
        if (arrowCount > 0)
        {
            SkinnedMeshRenderer bowRender = bowPrefab.transform.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer arrowRender = newArrow.transform.GetComponent<SkinnedMeshRenderer>();
            Rigidbody arrowRb = newArrow.transform.GetComponent<Rigidbody>();
            

            if (Input.GetMouseButton(0))
            {
                pullBowForce = pullBowForce + Time.deltaTime * pullBowSpeed;
                if (pullBowForce > 50)
                    pullBowForce = 50;

            }
            if (Input.GetMouseButtonUp(0))
            {
                pullBowForce = 0;
                isArrowAvaialble = false;
                arrowRb.isKinematic = false;
                newArrow.transform.parent = null;
                arrowCount = arrowCount - 1;

            }
            bowRender.SetBlendShapeWeight(0, pullBowForce);
            arrowRender.SetBlendShapeWeight(0, pullBowForce);
            if(Input.GetMouseButtonDown(0) && isArrowAvaialble == false)
            {
                GenerateArrow();
            }
        }
    }
}
