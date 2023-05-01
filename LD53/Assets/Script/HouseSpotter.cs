using UnityEngine;
using System.Collections;
using Camera = UnityEngine.Camera;


public class HouseSpotter : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private RectTransform circle;
    [SerializeField] private GameObject player;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (level.currentHouses.Count > 0)
        {
            circle.gameObject.SetActive(true);

            float minDis = Vector3.Distance(player.transform.position, level.currentHouses[0].transform.position);

            GameObject closestHouse = level.currentHouses[0];

            foreach (var currentHouse in level.currentHouses)
            {
                float tmpDis = Vector3.Distance(player.transform.position, currentHouse.transform.position);

                if (tmpDis < minDis)
                {
                    minDis = tmpDis;
                    closestHouse = currentHouse;
                }
            }

            circle.transform.position = cam.WorldToScreenPoint(closestHouse.transform.position);
        }
        else
        {
            circle.gameObject.SetActive(false);
        }
    }
}