module.exports = {
  env: {
    browser: true,
    es2021: true,
  },
  extends: [
    "airbnb",
    "airbnb-typescript",
    "airbnb/hooks",
    "plugin:@typescript-eslint/recommended",
    "plugin:react/recommended",
    "plugin:prettier/recommended",
  ],
  overrides: [
    {
      env: {
        node: true,
      },
      files: [".eslintrc.{js,cjs}"],
      parserOptions: {
        sourceType: "script",
      },
    },
  ],
  parser: "@typescript-eslint/parser",
  parserOptions: {
    ecmaVersion: "latest",
    sourceType: "module",
    project: "./tsconfig.json",
  },
  plugins: ["react", "@typescript-eslint", "prettier"],
  rules: {
    // Disabling the requirement for React to be in scope with JSX
    "react/react-in-jsx-scope": "off",
    // Disabling the requirement for file extensions in import statements
    "import/extensions": [
      "error",
      "ignorePackages",
      {
        "": "never",
        js: "never",
        jsx: "never",
        ts: "never",
        tsx: "never",
      },
    ],
    // Disabling the rule that prevents props spreading in TSX
    "react/jsx-props-no-spreading": "warn",
    // Disabling the rule that prevents the use of 'any' type in TypeScript
    "@typescript-eslint/no-explicit-any": "warn",
    "import/prefer-default-export": "off",
    "react/require-default-props": "warn",
    "jsx-a11y/label-has-associated-control": "off",
  },
};
