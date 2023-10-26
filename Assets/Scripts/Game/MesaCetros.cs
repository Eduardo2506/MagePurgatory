using UnityEngine;

public class MesaCetros : MonoBehaviour
{
    [SerializeField] private CetroController cetroNormalController;
    [SerializeField] private CetroFuegoController cetroFuegoController;
    [SerializeField] private CetroHieloController cetroHieloController;
    [SerializeField] private CetroRayoController cetroRayoController;
    [SerializeField] private CetroTierraController cetroTierraController;


    [SerializeField] private GameObject cetroNormal;

    [SerializeField] private GameObject cetroFuego;
    [SerializeField] private GameObject cetroHielo;
    [SerializeField] private GameObject cetroRayo;
    [SerializeField] private GameObject cetroTierra;

    [SerializeField] PlayerMovement panelCetros;
    public void CetroNormal()
    {
        Time.timeScale = 1f;
        //cetro.canShoot = false;
        cetroNormalController.canShoot = true;
        
        cetroFuegoController.canShoot = false;
        cetroHieloController.canShoot = false;
        cetroRayoController.canShoot = false;
        cetroTierraController.canShoot = false;

        cetroHielo.SetActive(false);
        cetroRayo.SetActive(false);
        cetroTierra.SetActive(false);
        cetroFuego.SetActive(false);

        cetroNormal.SetActive(true);
        panelCetros.panelMesaCetros.SetActive(false);
    }
    public void CetroFuego()
    {
        Time.timeScale = 1f;
        cetroFuegoController.canShoot = true;

        cetroHieloController.canShoot = false;
        cetroRayoController.canShoot = false;
        cetroTierraController.canShoot = false;
        cetroNormalController.canShoot = false;

        cetroNormal.SetActive(false);
        cetroHielo.SetActive(false);
        cetroRayo.SetActive(false);
        cetroTierra.SetActive(false);

        cetroFuego.SetActive(true);
        panelCetros.panelMesaCetros.SetActive(false);
    }
    public void CetroHielo()
    {
        Time.timeScale = 1f;

        cetroHieloController.canShoot = true;

        cetroFuegoController.canShoot = false;
        cetroRayoController.canShoot = false;
        cetroTierraController.canShoot = false;
        cetroNormalController.canShoot = false;

        cetroNormal.SetActive(false);
        cetroFuego.SetActive(false);
        cetroRayo.SetActive(false);
        cetroTierra.SetActive(false);

        cetroHielo.SetActive(true);
        panelCetros.panelMesaCetros.SetActive(false);
    }
    public void CetroRayo()
    {
        Time.timeScale = 1f;

        cetroRayoController.canShoot = true;

        cetroFuegoController.canShoot = false;
        cetroTierraController.canShoot = false;
        cetroNormalController.canShoot = false;
        cetroHieloController.canShoot = false;

        cetroNormal.SetActive(false);
        cetroFuego.SetActive(false);
        cetroTierra.SetActive(false);
        cetroHielo.SetActive(false);

        cetroRayo.SetActive(true);
        panelCetros.panelMesaCetros.SetActive(false);
    }
    public void CetroTierra()
    {
        Time.timeScale = 1f;

        cetroTierraController.canShoot = true;

        cetroFuegoController.canShoot = false;
        cetroNormalController.canShoot = false;
        cetroHieloController.canShoot = false;
        cetroRayoController.canShoot = false;

        cetroNormal.SetActive(false);
        cetroFuego.SetActive(false);
        cetroHielo.SetActive(false);
        cetroRayo.SetActive(false);

        cetroTierra.SetActive(true);
        panelCetros.panelMesaCetros.SetActive(false);
    }
}
