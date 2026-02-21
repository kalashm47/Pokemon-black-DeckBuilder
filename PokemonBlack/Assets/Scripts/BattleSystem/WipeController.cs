using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    public class WipeController : MonoBehaviour 
    {
        private Animator _animator;
        private Image _image;
        private readonly int _circleSizeId = Shader.PropertyToID("_Circle_float");
        
        public float circleSize = 0;
        public bool isIn = false;

        void Start() 
        {
            _animator = gameObject.GetComponent<Animator>();
            _image = gameObject.GetComponent<Image>();
        }

        public void AnimateIn() 
        {
            _animator.SetTrigger("In");
            isIn = true;
        }

        public void AnimateOut() 
        {
            _animator.SetTrigger("Out");
            isIn = false;
        }

        // Update is called once per frame
        void Update() 
        {
            // REMOVI a lógica do Input.GetKeyDown(KeyCode.Space)
            // Agora o wipe só é ativado pelo BattleStarter
            
            _image.materialForRendering.SetFloat(_circleSizeId, circleSize);
        }
    }
