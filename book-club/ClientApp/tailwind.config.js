module.exports = {
  future: {
    // removeDeprecatedGapUtilities: true,
    // purgeLayersByDefault: true,
  },
  purge: [],
  content: [
    "./src/components/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      width: {
        'sidebarWidth': '15vw',
        'mainWidth': '70vw'
      }
    },
  },
  variants: {},
  plugins: [],
}
