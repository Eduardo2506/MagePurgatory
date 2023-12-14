using Cinemachine;
using UnityEngine;

public class MovimientoCamera : MonoBehaviour
{
    public static MovimientoCamera Instance;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannePerlin;
    private float tiempoMovimiento;
    private float tiempoMovimientoTotal;
    private float intensidadInicial;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannePerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void MoverCamara(float intensidad, float frecuencia, float tiempo)
    {
        cinemachineBasicMultiChannePerlin.m_AmplitudeGain = intensidad;
        cinemachineBasicMultiChannePerlin.m_FrequencyGain = frecuencia;
        intensidadInicial = intensidad;
        tiempoMovimientoTotal = tiempo;
        tiempoMovimiento = tiempo;
    }
    private void Update()
    {
        if (tiempoMovimiento > 0)
        {
            tiempoMovimiento -= Time.deltaTime;
            cinemachineBasicMultiChannePerlin.m_AmplitudeGain = Mathf.Lerp(intensidadInicial, 0, 1 - (tiempoMovimiento / tiempoMovimientoTotal));
        }
    }
}
