const btnAbrirMenu = document.querySelector(".menu");
const menu = document.querySelector(".menulista");
const pantalla = document.querySelector(".container");
const botonUsuario = document.querySelector(".usuario");
const botonCarrito = document.querySelector(".carrito");
const menuCarrito = document.querySelector(".menuCarrito");
const menuUsuario = document.querySelector(".menuUsuario");
function BotonMenu() {
  if (menu.classList.contains("ocultar")) {
    menu.classList.remove("ocultar");
  } else if (!menu.classList.contains("ocultar")) {
    menu.classList.add("ocultar");
  }
}

function BotonCarrito() {
  if (menuCarrito.classList.contains("ocultar")) {
    menuCarrito.classList.remove("ocultar");
  } else if (!menuCarrito.classList.contains("ocultar")) {
    menuCarrito.classList.add("ocultar");
  }
}

function BotonUsuario() {
  if (menuUsuario.classList.contains("ocultar")) {
    menuUsuario.classList.remove("ocultar");
  } else if (!menuUsuario.classList.contains("ocultar")) {
    menuUsuario.classList.add("ocultar");
  }
}

document.addEventListener("keydown", function (e) {
  if (e.key === "Escape" && !menu.classList.contains("hidden")) {
    BotonMenu();
  }
});
btnAbrirMenu.addEventListener("click", BotonMenu);
botonCarrito.addEventListener("click", BotonCarrito);
botonUsuario.addEventListener("click", BotonUsuario);
