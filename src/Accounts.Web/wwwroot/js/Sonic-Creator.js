/*
 * Cria o spinner da tela de login
 * http://padolsey.github.io/sonic-creator/
 */

new Sonic({

    width: 100,
    height: 100,

    //backgroundColor: '#fff',

    stepsPerFrame: 4,
    trailLength: 1,
    pointDistance: 0.01,
    fps: 25,

    setup: function () {
        this._.lineWidth = 10;
    },

    step: function (point, i, f) {

        var progress = point.progress,
			degAngle = 360 * progress,
			angle = Math.PI / 180 * degAngle,
			angleB = Math.PI / 180 * (degAngle - 180),
			size = i * 5;

        //console.log(progress, i, f, size );

        this._.fillStyle = '#000';
        this._.fillRect(
            Math.cos(Math.PI / 180 * degAngle - 1) * 25 + (50 - size / 2),
			Math.sin(angle) * 25 + (50 - size / 2),
			size,
			size
		);

        this._.fillStyle = '#000';
        this._.fillRect(
            Math.cos(Math.PI / 180 * (degAngle - 180) + 1) * 25 + (50 - size / 2),
            Math.sin(angleB) * 25 + (50 - size / 2),
			size,
			size
		);
        /*
        this._.fillStyle = '#000';
		this._.fillRect(
			Math.cos(angle) * 25 + (50-size/2),
			Math.sin(angle) * 15 + (50-size/2),
			size,
			size
		); 
		this._.fillStyle = '#000';
		this._.fillRect(
			Math.cos(angleB) * 15 + (50-size/2),
			Math.sin(angleB) * 25 + (50-size/2),
			size,
			size
		);
        */
    },

    path: [
		['line', 0, 0, 1, 1] // stub -- not actually rendered
    ]

});