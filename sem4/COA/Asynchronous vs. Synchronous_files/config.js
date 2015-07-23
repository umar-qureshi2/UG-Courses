window.UTORRENT_CONTROL_VERSION = 0.76;

if (!window.console) {
window.console = { 
log: function() {},
warn:function(){},
error:function(){}
};
}

window.config = {
  track_events: false,
  static_prefix: '',
  webui: false,
  ssl: true,
  verbose: 10,
  asserts: true,
  compiled: true,
  jsonp: true,
  toolbar: true,
  cache_bust: false,
  cache_bust_version: UTORRENT_CONTROL_VERSION,
  static_root: 'http://download.staging.utorrent.com/toolbar-static/',
  stats_url: 'http://remote.utorrent.com/track',
  autologin_url: 'http://remote.utorrent.com/talon/autologin',
  srp_root: 'https://remote.utorrent.com'
};
var user_dev = (window.location.host.match('conduit.toolbar.dev'));
var lenny = (window.location.host.match('192.168.56.1') || window.location.host.match('10.0.3.3'));

var staging = (window.location.host.match('bar-staging.utorrent.com'));
var prod = (window.location.host.match('bar.utorrent.com'));
var limelight = (window.location.host.match('ll.download3.utorrent.com'));
var billybob = (window.location.host.match('10.10.90.23:7777'));

if (staging) {
  config.static_root = 'http://bar-staging.utorrent.com/';
  config.srp_root = 'https://remote-staging.utorrent.com';
  config.autologin_url = 'http://remote-staging.utorrent.com/talon/autologin';
  config.stats_url = 'http://remote-staging.utorrent.com/track';
  config.remotelog_server = 'http://10.10.90.24:9090';
  config.verbose = 2;
} else if (limelight) {
  config.static_root = 'http://ll.download3.utorrent.com/toolbar-static/';
  config.verbose = 1;
  config.asserts = false;
  config.compiled = true;
} else if (prod) {
  config.static_root = 'http://bar.utorrent.com/';
  config.verbose = 1;
  config.asserts = false;
} else if (user_dev) {
  config.static_root = 'http://conduit.toolbar.dev:8080/talonstatic/static/conduit/';
  config.cache_bust = true;
  config.compiled = false;
  config.asserts = true;
  //config.srp_root = 'https://10.10.90.242';
} else if (lenny) {
  //config.static_root = 'http://192.168.56.1:9090/static/conduit/';
  config.static_root = 'http://192.168.56.1:9090/static/conduit/';
  config.stats_url = 'http://192.168.56.1:9090/track';
//  config.autologin_url = 'http://192.168.56.1:9090/talon/autologin';
//  config.autologin_url = 'http://192.168.56.1/talon/autologin';
  config.cache_bust = true;
  config.compiled = false;
  config.asserts = true;
  config.ssl = false;
  config.remotelog_server = 'http://192.168.56.1:9090';
  config.srp_root = 'http://192.168.56.1:9090';
} else if (billybob) {
  config.static_root = 'http://10.10.90.23:7777/';
  config.stats_url = 'http://10.10.90.23:7777/track';
  config.cache_bust = true;
  config.compiled = false;
  config.asserts = true;
//  config.autologin_url = 'http://remote-staging.utorrent.com/talon/autologin';
//  config.srp_root = 'https://remote-staging.utorrent.com';
} else {
  config.static_root = 'http://'  + window.location.host + '/static/conduit/';
  config.cache_bust = true;
  config.compiled = false;
  config.asserts = true;
//  config.srp_root = 'http://10.10.90.242';
}
