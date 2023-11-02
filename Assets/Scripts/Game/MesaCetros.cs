using UnityEngine;
using UnityEngine.UI;

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

    public Image cetroPrincipal;
    public Image Cetro2;
    public Image Cetro3;
    public Image Cetro4;
    public Image Cetro5;

    private void Start()
    {
        cetroPrincipal.enabled = false;
        Cetro2.enabled = false;
        Cetro3.enabled = false;
        Cetro4.enabled = false;
        Cetro5.enabled = false;
    }
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

        cetroPrincipal.enabled = true;
        Cetro2.enabled = false;
        Cetro3.enabled = false;
        Cetro4.enabled = false;
        Cetro5.enabled = false;

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

        cetroPrincipal.enabled = false;
        Cetro2.enabled = true;
        Cetro3.enabled = false;
        Cetro4.enabled = false;
        Cetro5.enabled = false;

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

        cetroPrincipal.enabled = false;
        Cetro2.enabled = false;
        Cetro3.enabled = true;
        Cetro4.enabled = false;
        Cetro5.enabled = false;

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

        cetroPrincipal.enabled = false;
        Cetro2.enabled = false;
        Cetro3.enabled = false;
        Cetro4.enabled = true;
        Cetro5.enabled = false;

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

        cetroPrincipal.enabled = false;
        Cetro2.enabled = false;
        Cetro3.enabled = false;
        Cetro4.enabled = false;
        Cetro5.enabled = true;

        panelCetros.panelMesaCetros.SetActive(false);
    }
}
