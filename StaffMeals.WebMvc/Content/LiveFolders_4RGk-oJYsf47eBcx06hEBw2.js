﻿function stopDefaultAction(n){return n&&typeof n.preventDefault=="function"?n.preventDefault():window.event.returnValue=!1,!1}function _ge(n){return typeof n=="object"?n:document.getElementById(n)}function loadScript(n){var i=document,r=i.getElementsByTagName("head")[0],t=i.createElement("script");return t.src=n,r.appendChild(t),t}function getText(n){return document.all?n.innerText:n.textContent}function setText(n,t){document.all?n.innerText=t:n.textContent=t}function isDescendantOf(n,t){for(n=n.parentNode;n!=null;){if(n.tagName==t)return!0;n=n.parentNode}return!1}function setDisplay(n,t){n.style.display=t?"block":"none"}function resetDisplay(n){n.style.display=""}function setVisibility(n,t){n.style.visibility=t?"visible":"hidden"}function resetVisibility(n){n.style.visibility=""}function getTickCount(){var n=new Date;return n.getTime()}function isNullOrEmpty(n){return n===undefined||n===null||n.length===0}function first(n){return!!n&&!!n[0]?n[0]:null}function HideElement(n){!n||(addCssClass(n,"displayInvisible"),removeCssClass(n,"displayVisible"))}function ShowElement(n){!n||(removeCssClass(n,"displayInvisible"),addCssClass(n,"displayVisible"))}function selectNodes(n,t,i,r){var f,s,e,o,h,u;if(t||(t=function(){return!0}),i||(i="*"),f=[],!document.evaluate||!r)for(o=n.getElementsByTagName(i),h=o.length,u=0;u<h;u++)t(o[u])&&f.push(o[u]);else for(s=document.evaluate(r,n,null,0,null),e=s.iterateNext();!!e;)f.push(e),e=s.iterateNext();return f}function elementHasClassName(n,t){return(n.className?n.className.split(" "):[]).indexOf(t)>-1}function getChildByClassName(n,t){var u,i,r;if(n&&n.childNodes)for(u=n.childNodes.length,i=0;i<u;i++){if(elementHasClassName(n.childNodes[i],t))return n.childNodes[i];if(r=getChildByClassName(n.childNodes[i],t),r!=null)return r}return null}function getChildrenByClassName(n,t,i){var u,r;if(i||(i=[]),n&&n.childNodes)for(u=n.childNodes.length,r=0;r<u;r++)elementHasClassName(n.childNodes[r],t)&&(i[i.length]=n.childNodes[r]),getChildrenByClassName(n.childNodes[r],t,i);return i}function addCssClass(n,t){if(n.className!=null){var i=n.className?n.className.split(" "):[],r=i.indexOf(t);r===-1&&(i.push(t),n.className=i.join(" "))}else n.className=t}function removeCssClass(n,t){if(n.className!=null){var i=n.className.split(" "),r=i.indexOf(t);r!==-1&&(i.splice(r,1),n.className=i.join(" "))}}function prepareSubmitOnce(n){var t=!n.submitted;return t&&(n.submitted=!0,disableButton("actionPageSubmit"),disableButton("secondaryActionPageSubmit"),disableButton("cancelSubmit")),t}function trySubmit(n,t){var i=document.getElementById("aspnetForm"),r;i.onsubmit()&&(n&&(r=_ge("postVerb"),r&&(r.value=n)),i.target=t||"_top",i.submit())}function trySubmitData(n,t){var i,r;document.getElementById("aspnetForm").onsubmit()&&(t&&(i=_ge("postVerbData"),i&&(i.value=t)),n&&(r=_ge("postVerb"),r&&(r.value=n)),document.getElementById("aspnetForm").submit())}function focusAndSelectTextField(n){n&&(n.focus(),n.select())}function runBatchOperation(n,t,i,r){var s=20,f=n.length,u=0,o=10,e;(i===null||i===undefined)&&(i=function(){}),e=function(){for(var h=0;h<s&&u<f;h++,u++)t(n[u],r,u);u<f?window.setTimeout(e,o):u==f&&i(r)},window.setTimeout(e,o)}function hideButton(n){n=_ge(n),n!=null&&(n.style.display="none")}function showButton(n){n=_ge(n),n!=null&&(n.style.display="")}function disableButton(n){n=_ge(n),n!=null&&(n.disabled=!0)}function enableButton(n){n=_ge(n),n!=null&&(n.disabled=!1)}function callHandlerOnEnterKey(n,t){n=n?n:window.event?window.event:"";var r=n.target||n.srcElement,i=n.keyCode==3||n.keyCode==13||n.which==13;return i&&(n.preventDefault&&n.preventDefault(),window.event&&!n.which&&(window.event.keyCode=0),t&&t(r)),!i}function callHandlerOnEscKey(n,t){n=n?n:window.event?window.event:"";var r=n.target||n.srcElement,i=n.keyCode==27;return i&&(n.preventDefault&&n.preventDefault(),window.event&&!n.which&&(window.event.keyCode=0),t&&t(r)),!i}function purgeHandlers(n){var i=n.attributes,t,u,r;if(i)for(t=0;t<i.length;t++)r=i[t].name,typeof n[r]=="function"&&(n[r]=null);if(i=n.childNodes,i)for(t=0;t<i.length;t++)purgeHandlers(n.childNodes[t])}function loadAdImage(n,t,i){var u=_ge(n),r=document.createElement("img");r.alt=t,r.src=i,u.appendChild(r),u.style.visibility="visible"}function isChildOf(n,t){while(t&&t!==n&&t!=document)t=t.parentNode;return t===n}function isMenuOpen(n){return elementHasClassName(n,"on")}function closeMenu(n){n.style.display="none",removeCssClass(n,"on")}function toggleMenu(n,t){var i=_ge(t),r,u;isMenuOpen(i)?closeMenu(i):(r=i.style,u=_ge(n),r.top=u.offsetHeight+u.offsetTop+"px",r.left=u.offsetLeft+"px",r.display="block",addCssClass(i,"on"))}function hideOnEsc(n,t){var i=_ge(t);n=n?n:window.event?window.event:"",n.keyCode==27&&isMenuOpen(i)&&closeMenu(i)}function hideOnMouseUp(n,t,i){var r=_ge(i),f=_ge(t),u;n=n?n:window.event?window.event:"",u=n.target||n.srcElement,isChildOf(r,u)||isChildOf(f,u)||!isMenuOpen(r)||closeMenu(r)}function Range(n,t){this.start=n,this.end=t,this.contains=function(n){return this.isValid()&&n>=this.start&&n<=this.end},this.isValid=function(){return this.start!=-1}}function downloadToPhotoGallery(n,t,i,r,u,f,e){isDownloadToWlpgActive&&(wlpgWave3Installed?_ge(r).src="wlpg: /c "+n+" /r "+t+" /t "+i:wlpgWave2Installed?confirm(u+"\n\n"+f)==!0&&window.open(e):window.open(e)),isDownloadToWlpgActive=!1,setTimeout(function(){isDownloadToWlpgActive=!0},3e3)}function doOrderPrints(n){function r(){t&&(clearInterval(i),i=null,t.focus())}var u=n,f="windows_live_order_prints",e="width=510,height=230,top=120,channelmode=0,dependent=0,directories=0,fullscreen=0,location=0,menubar=0,resizable=1,scrollbars=1,status=0,toolbar=0",t=window.open(u,f,e),i=setInterval(r,50);$menu.closeAll()}function getPosition(n){var i=0,r=0,t;if(!!n){for(t=n;t;t=t.offsetParent)i+=t.offsetTop,r+=t.offsetLeft;for(t=n.parentNode;t&&t!=document.body;t=t.parentNode)t.scrollTop&&(i-=t.scrollTop),t.scrollLeft&&(r-=t.scrollLeft)}return{left:r,top:i}}function getViewportDimensions(){var n=document.documentElement,r=document.body,t,i;return self.innerHeight&&self.innerWidth?(t=self.innerWidth,i=self.innerHeight):n&&n.clientHeight?(t=n.clientWidth,i=n.clientHeight):r&&(t=r.clientWidth,i=r.clientHeight),{width:t,height:i}}function setCookie(n,t,i,r,u,f){var o,e;i&&(e=new Date,e.setTime(e.getTime()),i=i*864e5,o=new Date(e.getTime()+i)),document.cookie=n+"="+escape(t)+(i?";expires="+o.toGMTString():"")+(r?";path="+r:"")+(u?";domain="+u:"")+(f?";secure":"")}function getCookie(n){for(var r=n+"=",u=document.cookie.split(";"),t,i=0;i<u.length;i++){for(t=u[i];t.charAt(0)==" ";)t=t.substring(1,t.length);if(t.indexOf(r)==0)return t.substring(r.length,t.length)}return null}if(function(){function s(){var r=t("cookieStyle"),o=new RegExp("^http(?:s)?://(?:[A-Za-z0-9]*[.])*livefilestore(?:-int)?[.]com/","i"),n;if(r){r.parentNode.removeChild(r);for(var e=document.getElementsByTagName("img"),u=0,s=e.length;u<s;u++)n=e[u],n.src&&o.test(n.src)&&(n.style.visiblity="hidden",i.push(n))}else f()}function r(){u(i,0,i.length),f()}function u(n,t,i){for(var f=Math.min(i,t+o),r;t<f;)r=n[t],h(r),t++;setTimeout(function(){u(n,t,i)},0)}function h(n){function i(){n.style.visiblity="visible",t.onload=t.onerror=t.onabort=null,n.onload=n.onerror=n.onabort=null,t=n=null}function r(n){var t=n.src;n.onload=n.onerror=n.onabort=i,n.src=t+(t.indexOf("?")<0?"?":"&")+"r"+Math.random()}var t=new Image;t.onload=function(){n.src=n.src,i()},t.onerror=function(){r(n)},t.onabort=function(){i()},t.src=n.src}function f(){var n=t("temp_slideshow"),i=t("sl_slideshow"),r=t("slideshowTemplate");n&&i&&r&&(i.innerHTML=r.innerHTML,n.parentNode.removeChild(n))}var n=window,t=function(t){return n.document.getElementById(t)},e=n.cookieToss,o=10,i=[];(function c(){var t=document.getElementById("c_content");t&&t.parentNode&&t.parentNode.nextSibling?(s(),e&&(n.cookieToss.e?(n.cookieToss.e=0,n.cookieToss.c=1,r()):n.cookieToss.c||(n.cookieToss.c=r))):setTimeout(c,100)})()}(),!registerNamespace)var registerNamespace=Function.registerNamespace=function(n){for(var t=window,u=n.split("."),f=u.length,r,i=0;i<f;i++)r=u[i],t[r]||(t[r]={}),t=t[r]};Array.prototype.indexOf||(Array.prototype.indexOf=function(n,t){var r=this.length,i;if(r!=0)for(t=t||0,t<0&&(t=Math.max(0,r+t)),i=t;i<r;i++)if(this[i]==n)return i;return-1}),registerNamespace("Microsoft.Live.Folders.Web.Scripts"),!window.registerCommand||(window.registerCommand("trySubmit",trySubmit),window.registerCommand("trySubmitData",trySubmitData))