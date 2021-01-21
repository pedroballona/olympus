const cucumber = require('cypress-cucumber-preprocessor').default
const browserify = require('@cypress/browserify-preprocessor')

const options = {
  typescript: require.resolve('typescript'),
};
const b = browserify(options);

module.exports = on => {
  const options = browserify.defaultOptions
  options.browserifyOptions.extensions.unshift('.ts');
  options.browserifyOptions.plugin.unshift(['tsify', { project: '/cypress/tsconfig.json' }]);

  const c = cucumber({
    ...browserify.defaultOptions,
    ...options,
  })
  on('file:preprocessor', file => {
    if (file.filePath.includes('.feature')) {
      return c(file);
    }
    return b(file);
  })
}