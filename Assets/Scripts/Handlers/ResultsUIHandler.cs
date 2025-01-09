using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

using static GlobalEnums;

public class ResultsUIHandler : MonoBehaviour
{
    [Serializable]
    public struct Results
    {
        public string Name;
        public Sprite Icon;
        public AudioClip SoundClip;
        public ResultsType Type;
    }

    [SerializeField]
    private Image resultsIconDisplayer;

    [Space(5)]
    [SerializeField]
    private List<Results> results;

    private const float DefaultTransitionSpeed = 5.0f;

    public void Show(ResultsType resultType)
    {
        Results result = results.Find(resultData => resultData.Type == resultType);

        UpdateResultsGUI(result, async () =>
        {
            SoundManager.Instance.PlayClip(result.SoundClip);

            while (resultsIconDisplayer.transform.localScale.x < 1.0f)
            {
                resultsIconDisplayer.transform.localScale = Vector3.Lerp(resultsIconDisplayer.transform.localScale, Vector3.one, DefaultTransitionSpeed * Time.deltaTime);
                await Task.Yield();
            }
        });
    }

    public async void Hide()
    {
        while (resultsIconDisplayer.transform.localScale.x > 0.0f)
        {
            resultsIconDisplayer.transform.localScale = Vector3.Lerp(resultsIconDisplayer.transform.localScale, Vector3.zero, DefaultTransitionSpeed * Time.deltaTime);
            await Task.Yield();
        }
    }

    private void OnEnable()
    {
        DelegateEventsManager.Instance.RegisterEvents<ResultsType>((ResultsUIHandler_OnSubmittedResultsEvent, DelegateEventType.OnSubmittedResultsEvent));
    }

    private void OnDisable()
    {
        DelegateEventsManager.Instance.UnRegisterEvents<ResultsType>((ResultsUIHandler_OnSubmittedResultsEvent, DelegateEventType.OnSubmittedResultsEvent));
    }

    private void Start()
        => Hide();

    private void ResultsUIHandler_OnSubmittedResultsEvent(ResultsType resultType)
        => Show(resultType);

    private void UpdateResultsGUI(Results results, Action callbackResults = null)
    {
        if(resultsIconDisplayer == null)
        {
            throw new InvalidOperationException("UpdateResultsGUI failed: resultsIconDisplayer cannot be null.");
        }

        resultsIconDisplayer.sprite = results.Icon;

        callbackResults?.Invoke();
    }
}
