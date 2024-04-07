using UnityEngine;


    [RequireComponent(typeof(Collider2D))]

public class TokenInstance : MonoBehaviour

{
        private AudioSource tokenCollectAudio;
        public Animator anim;       
	    public int token;
        private bool take = false;

        //private Vars varT;
        //private GameObject tokens;

        void Start()
        {
            //varT = GetComponent<Vars>().Sumtoken(1,tokens);;
            tokenCollectAudio = GetComponent<AudioSource>();
            //tokens = GameObject.FindGameObjectWithTag("Token");
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (!take)
            {
                 if (collision.CompareTag("Player"))        
                {
                    collision.gameObject.GetComponent<Vars>().Sumtoken(token);
                    tokenCollectAudio.Play();
                    anim.SetTrigger("collected");
                    take = true;
                    Destroy(gameObject, 1f);
                }
            }
        }     
}
