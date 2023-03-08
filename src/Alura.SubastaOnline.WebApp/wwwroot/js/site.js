function anexaEventoNoCliqueBotoesRemoveLeilao() {
    let botoesRemocaoLeilao = document.querySelectorAll('.btnRemovesubasta');
    botoesRemocaoLeilao.forEach(btn => $(btn).on('click', () => {
        let subasta = $(btn).data();
        if (window.confirm(`Confirma borrar la subasta ${subasta.titulo}?`)) {
            jQuery.ajax({
                url: `/Subasta/Remove/${subasta.id}`,
                method: 'post',
                success: () => $(`.row-leilao-${subasta.id}`).hide('slow'),
                error: () => window.alert('Ocurrió un erro al borrar')
            });
        }
    }));
}

$(document).ready(function () {

    anexaEventoNoCliqueBotoesRemoveLeilao();

    
});