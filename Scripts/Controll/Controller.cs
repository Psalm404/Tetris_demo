using UnityEngine;

public class Controller : MonoBehaviour
{
    [HideInInspector]
    public Model model;
    [HideInInspector]
    public View view;
    [HideInInspector]
    public cameraManager cameraManager;
    [HideInInspector]
    public gameManager gameManager;
    private FSMSystem fsm;
    [HideInInspector]
    public AudioManager audioManager;
    private void Awake()
    {
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
        cameraManager = GetComponent<cameraManager>();
        gameManager = GetComponent<gameManager>();
        audioManager = GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeFSM();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void MakeFSM()
    {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>();
        foreach (FSMState state in states)
        {
            fsm.AddState(state, this);
        }
        MenuState s = GetComponentInChildren<MenuState>();
        fsm.SetCurrentState(s);
    }
}
