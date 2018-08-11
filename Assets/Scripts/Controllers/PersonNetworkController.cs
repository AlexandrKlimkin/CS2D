using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PersonNetworkController : MonoBehaviour, IPunObservable {

    private PhotonView _PhotonView;
    private Rigidbody _Rigidbody;
    private RotationController _RotationController;

    private bool _ValuesReceived;

    private List<Vector3> _Positions;
    private List<float> _Orientations;

    private void Awake() {
        _PhotonView = GetComponent<PhotonView>();
        _Rigidbody = GetComponent<Rigidbody>();
        _RotationController = GetComponent<RotationController>();
    }

    private void Start() {
        _Positions = new List<Vector3>();
        _Orientations = new List<float>();
    }

    private void FixedUpdate() {
        if (_PhotonView.isMine) {
            _Positions.Add(transform.position);
            _Orientations.Add(_RotationController.orientation);
        } else {
            if (_Positions.Count != 0) {
                var pos = _Positions[0];
                _Positions.Remove(pos);
                transform.position = pos;
            }
            if(_Orientations.Count != 0) {
                var orientation = _Orientations[0];
                _Orientations.Remove(orientation);
                _RotationController.orientation = orientation;
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            Debug.LogWarning(_Positions.Count);
            foreach(var pos in _Positions) {
                Debug.Log(pos);
            }
            stream.SendNext(_Positions.ToArray());
            _Positions.Clear();
            stream.SendNext(_Orientations.ToArray());
            _Orientations.Clear();
        }
        else {
            _Positions.AddRange((Vector3[])stream.ReceiveNext());
            _Orientations.AddRange((float[])stream.ReceiveNext());
        }
    }
}