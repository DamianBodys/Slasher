using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Cursor : MonoBehaviour {

    // Update is called once per frame
    void Update () {

        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
        

        //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        //Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        //lookPos = lookPos - transform.position;
        //float angle = Mathf.Atan2(lookPos.z, lookPos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }
    
}
