var source = new EventSource('/api/Zalo');  
  
source.onmessage = function (event) {  
    $('#chatTemplate').text(event.data);
};  