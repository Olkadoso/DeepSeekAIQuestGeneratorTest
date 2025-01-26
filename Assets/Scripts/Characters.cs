using UnityEngine;
using TMPro;

public class Characters : MonoBehaviour
{
    public enum State
    {
        Default,
        ObjectiveKill,
        ObjectiveSave,
        Killed,
        Saved
      
    }
    public State state;
    [SerializeField] private Material[] material;
    
    [SerializeField] private Camera mainCamera;
    
    [SerializeField] public string characterName;
    
    [SerializeField] private GameObject nameplate;
    [SerializeField] private Vector3 offset = new Vector3(0, 1, 0);
    
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        
        Vector3 localOffset = this.transform.position + offset;
        Instantiate(nameplate, localOffset, Quaternion.Euler(0,0,0), this.transform);
        
    }

    private void Update()
    {
        switch (state)
        {
            case State.ObjectiveKill:
                _renderer.material = material[0];
                break;
            case State.ObjectiveSave:
                _renderer.material = material[1];
                break;
            case State.Killed:
                _renderer.material.color = Color.red;
                break;
            case State.Saved:
                _renderer.material.color = Color.green;
                break;
            default:
                _renderer.material.color = Color.gray;
                break;
            
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Q) && state != State.Saved)
        {
            state = State.Killed;
        }
        if (Input.GetKey(KeyCode.E) && state != State.Killed)
        {
            state = State.Saved;
        }
        
    }
    
}
