module.exports = {
  env: {
    browser: true,
    es2021: true,
    node: true
  },
  extends: ['eslint:recommended', 'plugin:prettier/recommended'],
  ignorePatterns: ['node_modules/*', 'public/mockServiceWorker.js', 'generators/*'],
  parserOptions: {
    ecmaVersion: 'latest',
    sourceType: 'module',
    project: './tsconfig.json'
  },
  plugins: ['react', '@typescript-eslint', 'prettier', 'check-file'],
  overrides: [
    {
      files: ['**/*.ts', '**/*.tsx'],
      parser: '@typescript-eslint/parser',
      settings: {
        react: { version: 'detect' },
        'import/resolver': {
          typescript: {}
        }
      },
      env: {
        browser: true,
        es2021: true,
        node: true
      },
      extends: [
        'google',
        'eslint:recommended',
        'plugin:import/errors',
        'plugin:import/warnings',
        'plugin:import/typescript',
        'plugin:@typescript-eslint/recommended',
        'plugin:react/recommended',
        'plugin:react-hooks/recommended',
        'plugin:jsx-a11y/recommended',
        'plugin:prettier/recommended',
        'plugin:testing-library/react',
        'plugin:jest-dom/recommended',
        'plugin:tailwindcss/recommended',
        'plugin:vitest/legacy-recommended'
      ],
      rules: {
        'import/no-cycle': 'error',
        'linebreak-style': 0,
        'react/prop-types': 'off',
        'import/order': [
          'error',
          {
            groups: ['builtin', 'external', 'internal', 'parent', 'sibling', 'index', 'object'],
            'newlines-between': 'always',
            alphabetize: { order: 'asc', caseInsensitive: true }
          }
        ],
        'import/default': 'off',
        'import/no-named-as-default-member': 'off',
        'import/no-named-as-default': 'off',
        'react/react-in-jsx-scope': 'off',
        'jsx-a11y/anchor-is-valid': 'off',
        '@typescript-eslint/explicit-function-return-type': ['off'],
        '@typescript-eslint/explicit-module-boundary-types': ['off'],
        '@typescript-eslint/no-empty-function': ['off'],
        '@typescript-eslint/no-explicit-any': ['off'],
        'prettier/prettier': ['error', {}, { usePrettierrc: true }],
        'check-file/filename-naming-convention': [
          'error',
          {
            '**/*.{ts,tsx}': 'KEBAB_CASE'
          },
          {
            ignoreMiddleExtensions: true
          }
        ],
        'no-unused-vars': 'off',
        '@typescript-eslint/no-unused-vars': [
          'error',
          {
            argsIgnorePattern: '^_',
            varsIgnorePattern: '^_',
            caughtErrorsIgnorePattern: '^_'
          }
        ],
        'require-jsdoc': [
          'error',
          {
            require: {
              FunctionDeclaration: false,
              MethodDefinition: false,
              ClassDeclaration: false,
              ArrowFunctionExpression: false,
              FunctionExpression: false
            }
          }
        ]
      }
    },
    {
      plugins: ['check-file'],
      files: ['src/**/!(__tests__)/*'],
      rules: {
        'check-file/folder-naming-convention': [
          'error',
          {
            '**/*': 'KEBAB_CASE'
          }
        ]
      }
    }
  ]
};
