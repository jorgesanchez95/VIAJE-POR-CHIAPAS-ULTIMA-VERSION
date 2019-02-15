(function () {
    var $image = $('.img-container > img'),
        $dataX = $('#dataX'),
        $dataY = $('#dataY'),
        $dataHeight = $('#dataHeight'),
        $dataWidth = $('#dataWidth'),
        $dataRotate = $('#dataRotate'),
        options = {
            //    data: {
            //x: 0,
            //y: 0,   
            //width: 640,
            //  height: 360
            //},
            strict: false,
            responsive: true,
            checkImageOrigin: true,

            // modal: false,
            //guides: false,
            //center: false,
            // highlight: false,
            // background: false,
            autoCrop: false,
            // autoCropArea: 0.5,
            dragCrop: false,
            movable: false,
            // rotatable: false,
            zoomable: true,
            // touchDragZoom: false,
            // mouseWheelZoom: false,
            // cropBoxMovable: false,
            // cropBoxResizable: false,
            // doubleClickToggle: false,

            // minCanvasWidth: 320,
            // minCanvasHeight: 180,
            // minCropBoxWidth: 160,
            // minCropBoxHeight: 90,
            // minContainerWidth: 320,
            // minContainerHeight: 180,

            // build: null,
            // built: null,
            // dragstart: null,
            // dragmove: null,
            // dragend: null,
            // zoomin: null,
            // zoomout: null,

            aspectRatio: 4 / 3,
            //preview: '.img-preview',
            crop: function (data) {
                $dataX.val(Math.round(data.x));
                $dataY.val(Math.round(data.y));
                $dataHeight.val(Math.round(data.height));
                $dataWidth.val(Math.round(data.width));
                $dataRotate.val(Math.round(data.rotate));
            }
        };
    
    $image.on({
        'build.cropper': function (e) {
            //console.log(e.type);
        },
        'built.cropper': function (e) {
            //console.log(e.type);
        },
        'dragstart.cropper': function (e) {
            //console.log(e.type, e.dragType);
        },
        'dragmove.cropper': function (e) {
            //console.log(e.type, e.dragType);
        },
        'dragend.cropper': function (e) {
            //console.log(e.type, e.dragType);
        },
        'zoomin.cropper': function (e) {
            //console.log(e.type);
        },
        'zoomout.cropper': function (e) {
            //¿console.log(e.type);
        },
        'change.cropper': function (e) {
            //console.log(e.type);
        }
    }).cropper(options);

    // Import image
    var $inputImage = $('#inputImage'),
        URL = window.URL || window.webkitURL,
        blobURL;

    if (URL) {
        $inputImage.change(function () {
            var files = this.files,
                file;

            if (!$image.data('cropper')) {
                return;
            }

            if (files && files.length) {
                file = files[0];

                if (/^image\/\w+$/.test(file.type)) {
                    blobURL = URL.createObjectURL(file);
                    $image.one('built.cropper', function () {
                        URL.revokeObjectURL(blobURL); // Revoke when load complete
                    }).cropper('reset').cropper('replace', blobURL);
                    $inputImage.val($image.val);
                } else {
                    showMessage('Please choose an image file.');
                }
            }
        });
    } else {
        $inputImage.parent().remove();
    }


    // Options
    $('.docs-options :checkbox').on('change', function () {
        var $this = $(this),
            cropBoxData,
            canvasData;

        if (!$image.data('cropper')) {
            return;
        }

        options[$this.val()] = $this.prop('checked');

        cropBoxData = $image.cropper('getCropBoxData');
        canvasData = $image.cropper('getCanvasData');
        options.built = function () {
            $image.cropper('setCropBoxData', cropBoxData);
            $image.cropper('setCanvasData', canvasData);
        };

        $image.cropper('destroy').cropper(options);
    });


    // Tooltips
    //$('[data-toggle="tooltip"]').tooltip();

}());

(function () {
    var $image2 = $('.img-container2 > img'),
        $dataX2 = $('#dataX'),
        $dataY2 = $('#dataY'),
        $dataHeight2 = $('#dataHeight'),
        $dataWidth2 = $('#dataWidth'),
        $dataRotate2 = $('#dataRotate'),
        options = {
            //    data: {
            //x: 0,
            //y: 0,   
            //width: 640,
            //  height: 360
            //},
            strict: false,
            responsive: true,
            checkImageOrigin: true,

            // modal: false,
            //guides: false,
            //center: false,
            // highlight: false,
            // background: false,
            autoCrop: false,
            // autoCropArea: 0.5,
            dragCrop: false,
            movable: false,
            // rotatable: false,
            zoomable: true,
            // touchDragZoom: false,
            // mouseWheelZoom: false,
            // cropBoxMovable: false,
            // cropBoxResizable: false,
            // doubleClickToggle: false,

            // minCanvasWidth: 320,
            // minCanvasHeight: 180,
            // minCropBoxWidth: 160,
            // minCropBoxHeight: 90,
            // minContainerWidth: 320,
            // minContainerHeight: 180,

            // build: null,
            // built: null,
            // dragstart: null,
            // dragmove: null,
            // dragend: null,
            // zoomin: null,
            // zoomout: null,

            aspectRatio: 4 / 3,
            //preview: '.img-preview',
            crop: function (data) {
                $dataX2.val(Math.round(data.x));
                $dataY2.val(Math.round(data.y));
                $dataHeight2.val(Math.round(data.height));
                $dataWidth2.val(Math.round(data.width));
                $dataRotate2.val(Math.round(data.rotate));
            }
        };

    $image2.on({
        'build.cropper': function (e) {
            //console.log(e.type);
        },
        'built.cropper': function (e) {
            //console.log(e.type);
        },
        'dragstart.cropper': function (e) {
            //console.log(e.type, e.dragType);
        },
        'dragmove.cropper': function (e) {
            //console.log(e.type, e.dragType);
        },
        'dragend.cropper': function (e) {
            //console.log(e.type, e.dragType);
        },
        'zoomin.cropper': function (e) {
            //console.log(e.type);
        },
        'zoomout.cropper': function (e) {
            //console.log(e.type);
        },
        'change.cropper': function (e) {
            //console.log(e.type);
        }
    }).cropper(options);

    // Import image
    var $inputImage2 = $('#inputImage2'),
        URL2 = window.URL || window.webkitURL,
        blobURL2;

    if (URL2) {
        $inputImage2.change(function () {
            var files = this.files,
                file;

            if (!$image2.data('cropper')) {
                return;
            }

            if (files && files.length) {
                file = files[0];

                if (/^image\/\w+$/.test(file.type)) {
                    blobURL2 = URL2.createObjectURL(file);
                    $image2.one('built.cropper', function () {
                        URL2.revokeObjectURL(blobURL2); // Revoke when load complete
                    }).cropper('reset').cropper('replace', blobURL2);
                    $inputImage2.val($image2.val);
                } else {
                    showMessage('Please choose an image file.');
                }
            }
        });
    } else {
        $inputImage2.parent().remove();
    }


    // Options
    $('.docs-options :checkbox').on('change', function () {
        var $this = $(this),
            cropBoxData,
            canvasData;

        if (!$image2.data('cropper')) {
            return;
        }

        options[$this.val()] = $this.prop('checked');

        cropBoxData = $image2.cropper('getCropBoxData');
        canvasData = $image2.cropper('getCanvasData');
        options.built = function () {
            $image2.cropper('setCropBoxData', cropBoxData);
            $image2.cropper('setCanvasData', canvasData);
        };

        $image2.cropper('destroy').cropper(options);
    });


    // Tooltips
    //$('[data-toggle="tooltip"]').tooltip();

}());
