using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public float screenMovePercentage = 0.1f;

    Transform mTrans;
    Vector3 mMouse;
    Vector3 mTargetPos;
    Vector3 mTargetEuler;

    float leftPixels, upPixels, rightPixels, downPixels;

    void Start() {
        mTrans = transform;
        mMouse = Input.mousePosition;
        mTargetPos = mTrans.position;
        mTargetEuler = mTrans.rotation.eulerAngles;

        xPixels = Screen.width * screenMovePercentage;
        yPixels = Screen.height * screenMovePercentage;
    }

    void Update() {
        Vector3 delta = Input.mousePosition - mMouse;
        mMouse = Input.mousePosition;

        if (Input.GetMouseButton(0)) {
            mTargetEuler.y += Time.deltaTime * 10f * delta.x;
        }

        if (Input.GetMouseButton(1)) {
            Vector3 dir = transform.rotation * Vector3.forward;
            dir.y = 0f;
            dir.Normalize();
            Quaternion rot = Quaternion.LookRotation(dir);
            mTargetPos += rot * new Vector3(delta.x * 0.1f, 0f, delta.y * 0.1f);
        }

        print(mMouse.ToString());
        if (mMouse.x < xPixels || mMouse.x >  || mMouse.y < cursorMoveDistance || mMouse.y > 1 - cursorMoveDistance) {
            print("in range");
        }

        float deltaTime = Time.deltaTime * 8f;
        mTrans.position = Vector3.Lerp(mTrans.position, mTargetPos, deltaTime);
        mTrans.rotation = Quaternion.Slerp(mTrans.rotation, Quaternion.Euler(mTargetEuler), deltaTime);
    }
}
