var connect = require('connect');
var serveStatic = require('serve-static');
var fs = require('fs');

var serverapp = connect();
 serverapp.use(serveStatic(__dirname), {'index': ['index.html', 'index.htm']})

serverapp.listen(80, function(){
    console.log('Server running on 80...');
});