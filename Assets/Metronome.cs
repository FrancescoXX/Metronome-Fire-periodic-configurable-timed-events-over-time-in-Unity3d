using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

//SRP: Calls periodic configurable Events
public class Metronome : MonoBehaviour {

    CompositeDisposable disposables = new CompositeDisposable();

    public void EnableMetronome() {
        print("Metronome Activated!");
        disposables.Clear();

        Observable
            .Interval(TimeSpan.FromSeconds(Random.Range(1, 2)))
            .Subscribe(x => {
                //Call Event 1 happened...
                Debug.Log("Timed Event 1");
            })
            .AddTo(disposables);

        Observable
            .Interval(TimeSpan.FromSeconds(Random.Range(1, 5)))
            .Subscribe(x => {
                //Call Event 2 happened...
                Debug.Log("Timed Event 2");
            })
            .AddTo(disposables);
    }

    public void DisableMetronome() {
        print("Metronome Disabled!");
        disposables.Clear();
    }

    private void OnDisable() => disposables.Clear();
}