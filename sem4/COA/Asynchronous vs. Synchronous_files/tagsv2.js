var tags = [
    /* generic libraries */
    {name: "lib/common"},
    {name: "lib/underscore", requires: ["lib/common"]},
    {name: "lib/underscore.strings"},
    {name: "lib/jquery-1.6.2"},
    {name: "lib/jquery.jsonp-2.1.4",
     requires: ["lib/jquery-1.6.2"]},
    {name: "lib/jquery.json",
     requires: ["lib/jquery-1.6.2"]},
    {name: "lib/jquery.jstorage",
     requires: ["lib/jquery-1.6.2", "lib/jquery.json"]},
    {name: "lib/jquery.history",
     requires: ["lib/jquery-1.6.2"]},
    {name: "lib/jquery.cookie",
     requires: ["lib/jquery-1.6.2"]},
    {name: "lib/jquery.log",
     requires: ["lib/jquery-1.6.2"]},
    {name: "lib/jquery.idle-timer",
     requires: ["lib/jquery-1.6.2"]},
    /* encryption stuff */
    {name: "srp/sjcl"},
    {name: "srp/encryption",
     requires: ["lib/jquery.jstorage", "srp/sjcl", "lib/jquery.log", "lib/jquery.cookie"]},

    /* client/gui stuff */
    {name: "lib/excanvas"},
    {name: "lib/jquery.flot", requires: ["lib/excanvas", "lib/jquery"]},
    {name: "lib/jquery.flot.crosshair", requires: ["lib/jquery.flot"]},
    {name: "gui/graph", requires: ["lib/jquery.flot"]},

    {name: "lib/swfobject.src" },
    {name: "gui/uploaderv2" },
  {name: "lib/bdecode"},
    {name: "falcon",
        requires: ["lib/jquery", "lib/jquery.jstorage", "lib/bdecode"]},
    {name: "streaming/player",
        requires: ["lib/jquery"]},
    {name: "streaming/connect",
        requires: ["lib/object", "lib/jquery", "lib/jquery.log",
                   "srp/encryption", "lib/jquery.jstorage", "lib/helper"]},
    {name: "streaming/connect_local",
        requires: ["lib/jquery", "lib/jquery.log",
                   "srp/encryption", "lib/jquery.jstorage", "lib/helper"]},
    {name: "streaming/display",
        requires: ["lib/jquery.cookie", "streaming/connect", "streaming/connect_local", 
                   "lib/parseuri", "streaming/player", "event_tracking"]},
  {name: 'gui/send', requires: ['falcon']},
    /* language stuff */
    {name: "webui/lang/_"},
    {name: "webui/lang/en"},
    {name: "client/pairing"},
    {name: "client/upload"},
    {name: "client/api",
     requires: ["lib/underscore", "srp/encryption", "client/pairing"]},

    {name: "lib/uki.dev"},
    {name: "lib/uki-more"},
    
    {name: "lib/locale",
     requires: ["lib/jquery.cookie", "lib/underscore", "webui/lang/_", "webui/lang/en"]},
    {name:"lib/webui_compat"},
    {name:"webui/mootools"},
    {name: "webui/utils"},
    {name:"webui/stable"},
    {name:"webui/tabs"},
    {name:"webui/constants"},
    {name:"webui/logger"},
    {name:"webui/contextmenu", requires:["webui/mootools"]},
    {name:"webui/dialogmanager", requires:["webui/mootools", "webui/tabs","webui/stable","webui/constants","webui/logger"]},
    {name: "webui/webui", requires:["lib/locale","webui/dialogmanager","webui/contextmenu","lib/webui_compat", "webui/mootools", "webui/utils"]},
    //{name: "webui_init", requires:[]"webui/webui"]},
    {name: "webui/main", requires:["webui/webui"]},

    {name: "lib/parseuri"},
    {name: "featured_apps"},

    {name: "srp/SHA-1/SHA-1"},
    {name: "client/models",
     requires: ["lib/underscore", "featured_apps","client/client","srp/SHA-1/SHA-1","lib/jquery-1.6.2"]},

    {name: "demo", requires: ["client/models","lib/uki.dev"]},
    {name: "client/client", requires: ["client/api"]},
    {name: "sketch/sketch",
     requires: ["lib/underscore", "lib/jquery-1.6.2"]}, // thomas' click
  // tracking thingamajig

    {name: "client/ukiview",
     requires: ["lib/uki.dev",  "lib/uki-more",  "lib/uki.more.treelist", "client/models", "lib/underscore.strings", "gui/graph", "gui/uploaderv2", 'lib/swfobject.src','utweb']},

    {name: "utweb",
     requires: ["lib/underscore", "lib/underscore.strings", "client/api", "client/models", "lib/jquery-1.6.2", "webui/webui","srp/SHA-1/SHA-1", "lib/parseuri", "event_tracking","lib/jquery.idle-timer","sketch/sketch","featured_apps","webui/main","client/upload"]},
    {name: "event_tracking"},

    {name: 'btapp',
     requires: ['client/ukiview']},

     /* To fix Android 2.3.3 iFrame scrolling*/
    {name: "iscroll"},
    
    /* QR Code lightbox */
    {name: "jquery.lightbox/js/jquery.lightbox-0.5.pack"},

    /* Mixpanel and Google Analytics event tracking */


    {name: "compiled/utweb"},
    {name: "compiled/srp-handshake"},
    {name: "compiled/gui-toolbar"},
    {name: "compiled/gui-gadget"},
    {name: "compiled/webtop-banner"},
    {name: "compiled/streaming-display"},
    {name: "compiled/btapp" },
    {name: "compiled/btapp_whitespace_only" },
    {name: "compiled/falcon_whitespace_only" },
    {name: "compiled/srp-handshake_whitespace_only" },
    {name: "compiled/mobile_whitespace_only" },
    {name: "sessions"},

    /* srp handshake without login page */
    {name: "lib/jsbn"},
    {name: "lib/jsbn2",
        requires: ["lib/jsbn"]},

    {name:'rgraph/RGraph.common.core'},
/*
    {name:'rgraph/RGraph.common.context'},
    {name:'rgraph/RGraph.common.annotate'},
    {name:'rgraph/RGraph.common.tooltips'},
    {name:'rgraph/RGraph.common.zoom'},
    {name:'rgraph/RGraph.common.resizing'},
    */
    {name:'rgraph/RGraph.line', requires:['rgraph/RGraph.common.core'
/*
                                          'rgraph/RGraph.common.context',
                                          'rgraph/RGraph.common.annotate',
                                          'rgraph/RGraph.common.tooltips',
                                          'rgraph/RGraph.common.zoom',
                                          'rgraph/RGraph.common.resizing'
                                          */
                                         ]},
    {name:'rgraph/RGraph.scatter', requires:['rgraph/RGraph.common.core'
                                         ]},
{name:"lib/finger"},

  {name: 'gui/10ft_data' },
//    {name: "dashboard", requires: ["lib/jquery.jstorage","rgraph/RGraph.line","rgraph/RGraph.scatter", "lib/underscore"]},
    {name: "dashboard", requires: ["lib/jquery.jstorage","lib/jquery.flot", "rgraph/RGraph.line", "lib/underscore"]},
    {name: 'gui/10ft', requires: ["lib/jquery.jstorage", "lib/underscore", "gui/10ft_data", "client/models", "client/client","lib/remotelog","lib/finger"]},

/*    {name: "SHA-1",
        path: "/static/js/srp/SHA-1/"},
        */
    {name: "lib/helper" },
    {name: "srp/key_negotiation",
        requires: ["srp/encryption", "lib/jsbn2", "lib/helper", "lib/underscore", "client/client",
                             "lib/jquery.log", "lib/jquery.jstorage"]},
    {name: "srp/handshake",
     requires: ["srp/key_negotiation", "srp/encryption", "srp/sjcl", "lib/jsbn2", "srp/SHA-1/SHA-1", "event_tracking", "jquery.lightbox/js/jquery.lightbox-0.5.pack", "client/models","client/client"]},
/*
  {name: "conduit/BrowserCompApi"},
  {name: "conduit/ToolbarCompApi"},
  {name: "gui/toolbar_common", requires: ["conduit/ToolbarApi", "conduit/BrowserCompApi"]}, // these modules break compilation
  */
  {name:"lib/remotelog", requires: ['lib/jquery.json']},
  {name: "gui/toolbar_common", requires: ["lib/remotelog"] },
    {name: "gui/gadget",
     requires: ["srp/key_negotiation", "client/models", "client/api", "client/upload", "gui/toolbar_common"]},
    {name: "gui/toolbar",
     requires: ["srp/key_negotiation", "client/models", "client/api", "gui/toolbar_common", "gui/gadget"]},
    {name: "privacy",
        requires: ["lib/jquery-1.6.2"]},
    {name: 'gui/dynamic_webui',
        requires: ['lib/common','lib/underscore','lib/remotelog']},
{name: 'gui/vesteltest', requires: ['lib/remotelog']},
    {name: "gui/webuibasic", requires: ['client/client','lib/uki.dev',"demo"]},


    {name: "lib/remoteapi",
     requires: ["srp/key_negotiation", "client/models", "client/api"]}


];

/*
if (window.config && config.netfront && false){
    for (var i=0; i<tags.length; i++) {
        if (tags[i].name == 'client/client') {
            tags[i].requires.push('client/models');
            break;
        }
    }
}
*/

var jsLoader = new JSLoad(tags, "/static/js/");


