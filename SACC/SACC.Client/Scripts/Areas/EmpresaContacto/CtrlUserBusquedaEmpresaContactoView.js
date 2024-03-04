var CtrlUserBusquedaEmpresaContactoView = {
    evento:         null,
    inicializa:     function (evento) {
        this.evento = evento;

        if (this.evento == 'CTRL_USER_BUSQUEDA_EMPRESA_CONTACTO_VIEW') {
            this.tabla.inicializa();
            this.tabla.datos();
        };
    },
    tabla: {
        inicializa: function () {
            $('#dgDatosCtrlUserBusquedaEmpresaContacto').bootstrapTable({
                pagination: true,
                search:     false,
                columns: [
                    {
                        field:     'EmpresaContactoId',
                        title:     'Folio',
                        sortable:  true,
                        align:     'center'
                    },
                    {
                        field:     'NombreCompleto',
                        title:     'Nombre',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'Telefono',
                        title:     'Tel&eacute;fono',
                        sortable:  true,
                        align:     'left',
                    },
                    {
                        field:     'Extension',
                        title:     'Extensi&oacute;n',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'DepartamentoDescripcion',
                        title:     'Departamento',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'ContactoTipoDescripcion',
                        title:     'Tipo de Contacto',
                        sortable:  true,
                        align:     'left'
                    },
                    {
                        field:     'CorreoElectronico',
                        title:     'Email',
                        sortable:  true,
                        align:     'left',
                    },
                    {
                        field:     '',
                        title:     'Acción',
                        formatter: this.accion(),
                        events:    'EmpresaContacto_ActionEvents',
                        align:     'center'
                    }
                ]
            });
        },
        datos:      function () {
            var objJSON = {
                pEmpresaId: $('#txtEmpresaId').val(),
                pEstatusId: ESTATUS_ENTIDAD.ACTIVO
            };

            var json = JSON.stringify(objJSON, null, 2);

            var res = getJSON(
                URL.EmpresaContacto + 'CtrlUserEmpresaContactoViewJson',
                json
            );

            $('#dgDatosCtrlUserBusquedaEmpresaContacto').bootstrapTable("load", res.data.Datos);
        },
        accion:     function (value, row, index) {
            return [
                '<a class="editEmpresaContacto" href="javascript:void(0)" title="Editar">',
                '<i class="text-success fa fa-pencil fa-2x"></i>',
                '</a>',
                '<span>&nbsp;&nbsp;&nbsp;</span>',
                '<a class="removeEmpresaContacto" href="javascript:void(0)" title="Eliminar">',
                '<i class="text-danger fa fa-trash fa-2x"></i>',
                '</a>'
            ].join('');
        }
    },
};




window.EmpresaContacto_ActionEvents = {
    'click .editEmpresaContacto':   function (e, value, row, index) {
        $("#txtEmpresaContactoId").val(row.EmpresaContactoId);

        Empresa.AbreModalContacto('EDITAR');
    },
    'click .removeEmpresaContacto': function (e, value, row, index) {
        if (row.Baja == true) {
            swal('El registro esta inactivo.', '', 'info');
            return;
        };

        $(location).attr('href', URL.EmpresaContacto + 'Delete?pEmpresaContactoId=' + row.EmpresaContactoId);
    }
};