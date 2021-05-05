document.addEventListener("DOMContentLoaded", function () {
  document.getElementById("formulario").addEventListener('submit', validarFormulario);
});


function validarFormulario(evento) {
  evento.preventDefault();
  var usuario = document.getElementById('nombre').value;
  if (usuario.length == 0) {
    alert('No has escrito nada en el campo nombre');
    return;
  }
  var clave = document.getElementById('apellido').value;
  if (clave.length == 0) {
    alert('No has escrito nada en el campo apellido');
    return;
  }
  this.submit();
  alert('Hemos recibido tu contacto. Nos contactaremos a la brevedad.')
}

function limpiarFormulario() {
  document.getElementById("formulario").reset();
}


