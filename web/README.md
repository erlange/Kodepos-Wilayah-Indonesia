
---

# Kode Pos Indonesia

##### 🔥 Live demo: [https://erlange.github.io/Kodepos-Wilayah-Indonesia/](https://erlange.github.io/Kodepos-Wilayah-Indonesia/)


A high-performance, award-winning web for this repo. That's all folks!

![Kodepos Indonesia](https://raw.githubusercontent.com/erlange/Kodepos-Wilayah-Indonesia/master/img/kodepos.png)

* [**Get started**](#get-started)
* [**Installation**](#installation)
* [**Building and running in production mode**](#building-and-running-in-production-mode)
* [**Single-page app mode**](#single-page-app-mode)
* [**Using TypeScript**](#using-typescript)
* [**Deploying to the web**](#deploying-to-the-web)

It is a [Svelte](https://svelte.dev) boilerplate app with [routing](https://github.com/mefechoel/svelte-navigator) and [TypeScript](https://www.typescriptlang.org/) support, [Babel](https://babeljs.io/) to facilitate running on ancient browsers such as IE11 and UI from [Materialize-CSS](https://materializecss.com/) and [FontAwesome](https://fontawesome.com/).


## Get started

*Note that you will need to have [Node.js](https://nodejs.org) installed.*

### Installation

Download the [zip file](https://github.com/erlange/Kodepos-Wilayah-Indonesia/archive/refs/heads/master.zip) or clone this repository:

```bash
mkdir [your-local-directory]
cd [your-local-directory]
git clone https://github.com/erlange/Kodepos-Wilayah-Indonesia.git
cd Kodepos-Wilayah-Indonesia
cd web
npm install
```

...then start [Rollup](https://rollupjs.org):

```bash
npm run dev
```

Use your browser, go to [http://localhost:5432/Kodepos-Wilayah-Indonesia](http://localhost:5432/Kodepos-Wilayah-Indonesia). You should see your app running. Edit a component file in `src`, save it, and reload the page to see your changes.

Change [this line in app.svelte](https://github.com/erlange/Kodepos-Wilayah-Indonesia/blob/master/web/src/App.svelte#L14) to configure the base-href other than `/Kodepos-Wilayah-Indonesia`

Change the port by editing [this line in package.json](https://github.com/erlange/Kodepos-Wilayah-Indonesia/blob/master/web/package.json#L8) file.

By default, the server will only respond to requests from localhost. To allow connections from other computers, edit the `sirv` commands in package.json to include the option `--host 0.0.0.0`.

If you're using [Visual Studio Code](https://code.visualstudio.com/) we recommend installing the official extension [Svelte for VS Code](https://marketplace.visualstudio.com/items?itemName=svelte.svelte-vscode). If you are using other editors you may need to install a plugin in order to get syntax highlighting and intellisense.

## Building and running in production mode

To create an optimised version of the app:

```bash
npm run build
```

You can run the newly built app with `npm run start`. This uses [sirv](https://github.com/lukeed/sirv), which is included in your package.json's `dependencies` so that the app will work when you deploy to platforms like [Heroku](https://heroku.com).


## Single-page app mode

By default, sirv will only respond to requests that match files in `public`. This is to maximise compatibility with static fileservers, allowing you to deploy your app anywhere.

If you're building a single-page app (SPA) with multiple routes, sirv needs to be able to respond to requests for *any* path. You can make it so by editing the `"start"` command in package.json:

```js
"start": "sirv public --single"
```

## Using TypeScript

This template comes with a script to set up a TypeScript development environment, you can run it immediately after cloning the template with:

```bash
node scripts/setupTypeScript.js
```

Or remove the script via:

```bash
rm scripts/setupTypeScript.js
```

## Deploying to the web

### With [Vercel](https://vercel.com)

Install `vercel` if you haven't already:

```bash
npm install -g vercel
```

Then, from within your project folder:

```bash
cd public
vercel deploy --name my-project
```

### With [surge](https://surge.sh/)

Install `surge` if you haven't already:

```bash
npm install -g surge
```

Then, from within your project folder:

```bash
npm run build
surge public my-project.surge.sh
```
---
*Looking for a shareable component template? Go here --> [sveltejs/component-template](https://github.com/sveltejs/component-template)*

© 2021 -  [erlange](mailto:eri.airlangga@gmail.com)