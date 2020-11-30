const COMPANIES = "companies";
const EMPLOYEES = "employees";

let currentList = COMPANIES;

function constructList(pageNumber, pageSize){
    $('#list').empty();

    if (currentList === COMPANIES){
        constructTableHeader('Компания', '', '');

        $.ajax({
            async: false,
            url:"http://localhost:61034/api/companies?pagenumber=" + pageNumber + "&pagesize=" + pageSize,
            method: "GET",
            success: function(companyPage){

                for(let i = 0; i < companyPage.items.length; i++){
                    constructRow(companyPage.items[i]);
                }

                $('#pageCount').empty().append(companyPage.pageCount);
            }
        });       
    }
    else if(currentList === EMPLOYEES){
        constructTableHeader('Имя', 'Фамилия', 'Отчество','Телефон', 'Компания', '', '');

        $.ajax({
            async: false,
            url:"http://localhost:61034/api/employees?pagenumber=" + pageNumber + "&pagesize=" + pageSize,
            method: "GET",
            success: function(employeePage){

                for(let i = 0; i < employeePage.items.length; i++){
                    constructRow(employeePage.items[i]);
                }

                $('#pageCount').empty().append(employeePage.pageCount);
            }
        });
    }
}

function constructTableHeader(...tableHeaders){
    let headers = '';

    for(let i = 0; i < tableHeaders.length; i++){
        headers += '<th>' + tableHeaders[i] + '</th>';
    }

    let headRow = '<tr>' + headers + '</tr>'

    $('#list').append(headRow);
}

function constructRow(item){
    let row = '';

    if (currentList === COMPANIES){
        row = '<tr id="' + item.id + '">' 
        + '<td id="title' + item.id + '" class="w-50">' + item.title + '</td>' 
        + '<td><input id="edit' + item.id + '" type="button" value="Редактировать"></td>' 
        + '<td><input id="remove' + item.id + '" type="button" value="Удалить"></td></tr>';
    }
    else if (currentList === EMPLOYEES){
        row = '<tr id="' + item.id + '">'
        + '<td id="firstName' + item.id + '">' + item.firstName + '</td>'
        + '<td id="lastName' + item.id + '">' + item.lastName + '</td>'
        + '<td id="middleName' + item.id + '">' + item.middleName + '</td>'
        + '<td id="phone' + item.id + '">' + item.phone + '</td>'
        + '<td id="company' + item.id + '">' + item.company + '</td>'
        + '<td><input id="edit' + item.id + '" type="button" value="Редактировать"></td>' 
        + '<td><input id="remove' + item.id + '" type="button" value="Удалить"></td></tr>';
    }

    $('#list').append(row);

    setHandlers(item.id);
}

function applyPageOptions(){
    $('#addPage').empty().hide();
    $('#editPage').empty().hide();
    $('#mainPage').show(); 

    let pageNumber = $('#pageNumber').val();
    let pageSize = $('#pageSize').val();

    constructList(pageNumber, pageSize)
};

function setHandlers(itemId){
    $('#edit'+itemId).click(function(){
        $('#mainPage').hide(); 

        $('#editPage').show();

        if (currentList === COMPANIES){
            let addTable = '<table>'
            +'<tr>'
            +'<td>Название:</td>'
            +'<td><input id="title" type="text" value="' + $('#title' + itemId).html() + '" placeholder="Название" /></td>'
            +'</tr>'
            +'</table>'
            +'<input id="save" type="button" value="Сохранить" />'
            +'<input id="cancel" type="button" value="Отмена" />';
        
            $('#editPage').empty().append(addTable);           
        }
        else if (currentList === EMPLOYEES){
            let addTable = '<table>'
                +'<tr>'
                    +'<td>Имя:</td>'
                    +'<td><input id="firstName" type="text" value="' + $('#firstName' + itemId).html() + '" placeholder="Имя" /></td>'
                +'</tr>'
                +'<tr>'
                    +'<td>Фамилия:</td>'
                    +'<td><input id="lastName" type="text" value="' + $('#lastName' + itemId).html() + '" placeholder="Фамилия" /></td>'
                +'</tr>'
                +'<tr>'
                    +'<td>Отчество:</td>'
                    +'<td><input id="middleName" type="text" value="' + $('#middleName' + itemId).html() + '" placeholder="Отчество" /></td>'
                +'</tr>'
                +'<tr>'
                    +'<td>Телефон:</td>'
                    +'<td><input id="phone" type="text" value="' + $('#phone' + itemId).html() + '" placeholder="Телефон" /></td>'
                +'</tr>'
                +'<tr>'
                    +'<td>Компания:</td>'
                    +'<td><select id="companySelect"></select></td>'
                +'</tr>'
            +'</table>'
            +'<input id="save" type="button" value="Сохранить" />'
            +'<input id="cancel" type="button" value="Отмена" />';
        
            $('#editPage').empty().append(addTable);

            $.ajax({
                async: false,
                url:"http://localhost:61034/api/companies/all",
                method: "GET",
                success: function(companies){
                    for(let i = 0; i < companies.length; i++){
                        let option = '';

                        if (companies[i].title ===  $('#company' + itemId).html()){
                            option = '<option id="' + companies[i].id + '" selected>' + companies[i].title + '</option>';
                        }
                        else{
                            option = '<option id="' + companies[i].id + '">' + companies[i].title + '</option>';
                        }
                        
                        $('#companySelect').append(option);
                    }
                }              
            }); 
        }

        $('#save').click(function() {
            if (currentList === COMPANIES){
                body = {
                    title: $('#title').val()
                };

                $.ajax({
                    async: false,
                    url:"http://localhost:61034/api/" + currentList + "/" + itemId,
                    method: "PUT",
                    dataType: "json",
                    contentType: 'application/json',
                    data: JSON.stringify(body),               
                }); 

                applyPageOptions();
            }
            else if (currentList === EMPLOYEES){
                body = {
                    firstName: $('#firstName').val(),
                    lastName: $('#lastName').val(),
                    middleName: $('#middleName').val(),
                    phone: $('#phone').val(),
                    companyId: $('#companySelect option:selected').attr('id')
                };

                $.ajax({
                    async: false,
                    url:"http://localhost:61034/api/" + currentList + "/" + itemId,
                    method: "PUT",
                    dataType: "json",
                    contentType: 'application/json',
                    data: JSON.stringify(body),               
                }); 

                applyPageOptions();
            }
        });  
        
        $('#cancel').click(function() {
            applyPageOptions();
        });
    });

    $('#remove'+itemId).click(function(){
        let itemId = $(this).closest('tr').attr('id');

        $.ajax({
            async: false,
            url:"http://localhost:61034/api/" + currentList + "/"+ itemId,
            method: "DELETE"
        });

        $(this).closest('tr').detach();
    });
}

$(document).ready(function(){
    $('#companies').click(function(){
        currentList = COMPANIES;
        $('#listName').empty().append('Компании');
        applyPageOptions();
    });

    $('#employees').click(function(){
        currentList = EMPLOYEES;
        $('#listName').empty().append('Сотрудники');
        applyPageOptions();
    });   

    $('#add').click(function(){
        $('#mainPage').hide(); 

        $('#addPage').show();

        if (currentList === COMPANIES){
            let addTable = '<table>'
            +'<tr>'
            +'<td>Название:</td>'
            +'<td><input id="title" type="text" placeholder="Название" /></td>'
            +'</tr>'
            +'</table>'
            +'<input id="save" type="button" value="Сохранить" />'
            +'<input id="cancel" type="button" value="Отмена" />';
        
            $('#addPage').empty().append(addTable);           
        }
        else if (currentList === EMPLOYEES){
            let addTable = '<table>'
                +'<tr>'
                    +'<td>Имя:</td>'
                    +'<td><input id="firstName" type="text" placeholder="Имя" /></td>'
                +'</tr>'
                +'<tr>'
                    +'<td>Фамилия:</td>'
                    +'<td><input id="lastName" type="text" placeholder="Фамилия" /></td>'
                +'</tr>'
                +'<tr>'
                    +'<td>Отчество:</td>'
                    +'<td><input id="middleName" type="text" placeholder="Отчество" /></td>'
                +'</tr>'
                +'<tr>'
                    +'<td>Телефон:</td>'
                    +'<td><input id="phone" type="text" placeholder="Телефон" /></td>'
                +'</tr>'
                +'<tr>'
                    +'<td>Компания:</td>'
                    +'<td><select id="companySelect"></select></td>'
                +'</tr>'
            +'</table>'
            +'<input id="save" type="button" value="Сохранить" />'
            +'<input id="cancel" type="button" value="Отмена" />';
        
            $('#addPage').empty().append(addTable);

            $.ajax({
                async: false,
                url:"http://localhost:61034/api/companies/all",
                method: "GET",
                success: function(companies){
                    for(let i = 0; i < companies.length; i++){
                        let option = '<option id="' + companies[i].id + '">' + companies[i].title + '</option>';
                        $('#companySelect').append(option);
                    }
                }              
            }); 
        }

        $('#save').click(function() {
            if (currentList === COMPANIES){
                body = {
                    title: $('#title').val()
                };

                $.ajax({
                    async: false,
                    url:"http://localhost:61034/api/" + currentList,
                    method: "POST",
                    dataType: "json",
                    contentType: 'application/json',
                    data: JSON.stringify(body),               
                }); 

                applyPageOptions();
            }
            else if (currentList === EMPLOYEES){
                body = {
                    firstName: $('#firstName').val(),
                    lastName: $('#lastName').val(),
                    middleName: $('#middleName').val(),
                    phone: $('#phone').val(),
                    companyId: $('#companySelect option:selected').attr('id')
                };

                $.ajax({
                    async: false,
                    url:"http://localhost:61034/api/" + currentList,
                    method: "POST",
                    dataType: "json",
                    contentType: 'application/json',
                    data: JSON.stringify(body),               
                }); 

                applyPageOptions();
            }
        });  
        
        $('#cancel').click(function() {
            applyPageOptions();
        }); 
    });
});
