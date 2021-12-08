using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameController;
using UnityEngine.SceneManagement;

namespace trophies.a {
    public class ATrophies : MonoBehaviour
    {
        public float maxSize;
        public float growRate;

        public Transform gameController;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, .0005f * Mathf.Sin(Time.time * 5), 0), 1);

            transform.Rotate(0, 100 * Time.deltaTime, 0);
        }

        public void test(){
            gameController.GetComponent<GameController>().turnGameOff();
            StartCoroutine(goBigThanGone());
        }

        IEnumerator goBigThanGone(){
            bool goingBig = true;
            bool loop = true;
            while (loop){
                if (goingBig){
                    transform.localScale = transform.localScale + (new Vector3(growRate, growRate, growRate) * Time.deltaTime);
                }else{
                    transform.localScale = transform.localScale - (new Vector3(growRate, growRate, growRate) * Time.deltaTime);
                }

                if(transform.localScale.x >= maxSize){
                    goingBig = false;
                }

                if(transform.localScale.x < 0){
                    loop = false;
                    transform.localScale = Vector3.zero;
                    transform.parent.GetComponent<ParticleSystem>().Stop();
                    yield return new WaitForSeconds(2);
                    SceneManager.LoadScene("End");
                }

                yield return null;
            }
        }
    }
}
