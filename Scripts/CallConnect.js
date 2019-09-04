

// this is on button click, figure out later but for now do this

document.getElementById('button-call').onclick = function () {

    const params = { To: '15558675310' };

    console.log('Calling' + params.To + '...');
    Twilio.Device.connect(params);
};

//hangup 

document.getElementById('button-hangup').onclick = function () {
    console.log('Hanging up...');
    Twilio.Device.disconnectAll();

};