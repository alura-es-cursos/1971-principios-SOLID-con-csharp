using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Alura.SubastaOnline.WebApp.Controllers;

namespace Alura.SubastaOnline.Testes
{
    public class SubastaControllerRemove
    {
        [Fact]
        public void DadoSubastaInexistenteEntaoRetorna404()
        {
            // arrange
            var idSubastaInexistente = 11232; // preciso entrar no banco para saber qual � inexistente!! teste deixa de ser autom�tico...
            var actionResultEsperado = typeof(NotFoundResult);
            var controller = new SubastaController();

            // act
            var result = controller.Remove(idSubastaInexistente);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoSubastaEmPregaoEntaoRetorna405()
        {
            // arrange
            var idSubastaEmPregao = 11232; // qual Subasta est� em preg�o???!! 
            var actionResultEsperado = typeof(StatusCodeResult);
            var controller = new SubastaController();

            // act
            var result = controller.Remove(idSubastaEmPregao);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoSubastaEmRascunhoEntaoExcluiORegistro()
        {
            // arrange
            var idSubastaEmRascunho = 11232; // qual Subasta est� em rascunho???!!
            var actionResultEsperado = typeof(NoContentResult);
            var controller = new SubastaController();

            // act
            var result = controller.Remove(idSubastaEmRascunho);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }
    }
}
