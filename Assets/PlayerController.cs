using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{

    private Vector2 _direction;
     private Vector3 _moveDirection;

    [SerializeField] float _speed;

    [SerializeField] CharacterController _controller;

    private void Update() {
         _moveDirection = new Vector3(_direction.x, 0, _direction.y);
         Debug.Log(_moveDirection);
    }
    private void FixedUpdate()
    {
       
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }


    // private Vector2Int IsoVectorConvert(Vector2Int vector)
    // {
    //     if (vector == new Vector2Int(0, 1))
    //     {
    //         return new Vector2Int(1, 1);
    //     }
    //     else if (vector == new Vector2Int(1, 1))
    //     {
    //         return new Vector2Int(1, 0);
    //     }
    //     else if (vector == new Vector2Int(1, 0))
    //     {
    //         return new Vector2Int(1, -1);
    //     }
    //     else if (vector == new Vector2Int(1, -1))
    //     {
    //         return new Vector2Int(0, -1);
    //     }
    //     else if (vector == new Vector2Int(0, -1))
    //     {
    //         return new Vector2Int(-1, -1);
    //     }
    //     else if (vector == new Vector2Int(-1, -1))
    //     {
    //         return new Vector2Int(-1, 0);
    //     }
    //     else if (vector == new Vector2Int(-1, 0))
    //     {
    //         return new Vector2Int(-1, 1);
    //     }
    //     else if (vector == new Vector2Int(-1, 1))
    //     {
    //         return new Vector2Int(0, 1);
    //     }
    //     else
    //     {
    //         Debug.Log(vector + " cannot be converted.");
    //         return new Vector2Int(0, 0);
    //     }

    // }

    private Vector3 IsoVectorConvert(Vector3 vector)
    {
        Quaternion rotation = Quaternion.Euler(0,45,0);
        Matrix4x4 isoMatrix = Matrix4x4.Rotate(rotation);
        Vector3 result = isoMatrix.MultiplyPoint3x4(vector);
        Debug.Log(result);
        return result;

    }
    public void OnFire(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLook(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
       // _direction = context.ReadValue<Vector2>();
    //     Vector2  readVector = context.ReadValue<Vector2>();
    //   //  readVector = Quaternion.Euler(0,0,45) * readVector;
    //     Vector3 toConvert = new Vector3 (readVector.x,readVector.y,0);
    //     _direction = IsoVectorConvert(toConvert);
    }
}
