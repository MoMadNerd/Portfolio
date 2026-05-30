# 🚀 GitHub Deployment Guide

## Table of Contents

- [Option 1: Single Repository](#option-1-single-repository-with-all-projects)
- [Option 2: Individual Repositories](#option-2-individual-repositories)
- [Option 3: GitHub Pages](#option-3-github-pages-deployment)
- [Option 4: Netlify/Vercel](#option-4-netlifyvercel)
- [Pre-Deployment Checklist](#pre-deployment-checklist)
- [Troubleshooting](#troubleshooting)

---

## Option 1: Single Repository with All Projects

### Step 1: Prepare Your Portfolio Repository

```bash
cd F:\MoFiles\Portfolio

# Initialize git repository
git init

# Add all projects and documentation
git add PortfolioWebsite/ AngularDashboard/ AnalyticsDashboard/ DOCS.md README.md

# Create initial commit
git commit -m "Initial commit: Full-stack developer portfolio with 3 demo projects"

# Add your GitHub remote
git remote add origin https://github.com/YOUR_USERNAME/fullstack-portfolio.git

# Push to GitHub
git branch -M main
git push -u origin main
```

### Step 2: Create a Production Build (for GitHub Pages)

```bash
# Build Portfolio Website
cd PortfolioWebsite
npm run build
cd ..

# Build Angular Dashboard
cd AngularDashboard
npm run build
cd ..

# Build Analytics Dashboard
cd AnalyticsDashboard
npm run build
cd ..
```

### Step 3: Enable GitHub Pages

1. Go to your repository on GitHub
2. Settings → Pages
3. Source: Deploy from branch `main`
4. Folder: `/root` (for all projects) or `/portfolio-website`, `/angular-dashboard`, `/analytics`
5. Click Save

---

## Option 2: Individual Repositories

Create separate repositories for each project:

### Portfolio Website

```bash
cd F:\MoFiles\Portfolio\PortfolioWebsite
git init
git add .
git commit -m "Initial commit: Portfolio website"
git remote add origin https://github.com/YOUR_USERNAME/portfolio-website.git
git push -u origin main
```

### Angular Dashboard

```bash
cd F:\MoFiles\Portfolio\AngularDashboard
git init
git add .
git commit -m "Initial commit: E-commerce dashboard"
git remote add origin https://github.com/YOUR_USERNAME/angular-dashboard.git
git push -u origin main
```

### Analytics Dashboard

```bash
cd F:\MoFiles\Portfolio\AnalyticsDashboard
git init
git add .
git commit -m "Initial commit: Real-time analytics dashboard"
git remote add origin https://github.com/YOUR_USERNAME/analytics-dashboard.git
git push -u origin main
```

---

## Option 3: GitHub Pages Deployment (Recommended)

### Single Page Portfolio (GitHub Pages)

1. **Build the production version:**
   ```bash
   cd F:\MoFiles\Portfolio\PortfolioWebsite
   ng build --configuration=production --base-href=/YOUR_USERNAME/portfolio-website/
   ```

2. **Upload to GitHub:**
   - Option A: Use `gh-pages` package
   - Option B: Upload `dist/` folder directly to GitHub repository

3. **Enable GitHub Pages:**
   - Go to Settings → Pages
   - Select branch: `gh-pages` (if using gh-pages) or `main`
   - Folder: `/` or `/portfolio-website`

4. **Custom Domain (Optional):**
   - Settings → Pages → Custom domain
   - Add DNS records (CNAME or A records)

### Multi-Project Showcase

Create a GitHub Pages site that showcases all projects:

1. Build each project separately
2. Create a landing page linking to all projects
3. Deploy with a structure like:
   ```
   /
   ├── index.html (landing page)
   ├── portfolio-website/
   ├── angular-dashboard/
   └── analytics-dashboard/
   ```

---

## Option 4: Netlify/Vercel Deployment

### Netlify

1. Push code to GitHub
2. Go to [netlify.com](https://netlify.com)
3. "Import from Git" → Select your repository
4. Build command: `npm run build`
5. Publish directory: `dist/`
6. Deploy!

### Vercel

1. Push code to GitHub
2. Go to [vercel.com](https://vercel.com)
3. "Import Git Repository"
4. Vercel auto-detects Angular configuration
5. Deploy!

---

## Pre-Deployment Checklist

- [ ] Update README.md with project links
- [ ] Replace placeholder email with your actual email
- [ ] Add GitHub username to contact info
- [ ] Test all pages work in production build
- [ ] Optimize images (use WebP format)
- [ ] Add meta tags for SEO
- [ ] Verify contact form works
- [ ] Test on mobile devices
- [ ] Remove `.env` files (don't commit secrets)

---

## Troubleshooting

### Build Fails with "Module Not Found"

```bash
# Clear cache and reinstall
rm -rf node_modules package-lock.json
npm install
```

### GitHub Pages Shows 404

- Verify `index.html` exists in `dist/` folder
- Check GitHub Pages settings (branch and folder)
- Wait 2-3 minutes for DNS propagation

### Custom Domain Not Working

- Check DNS TTL (Time To Live)
- Wait up to 48 hours for propagation
- Verify DNS records are correct

---

## 🔗 Useful Links

- [Angular Deployment Guide](https://angular.dev/guide/deployment)
- [GitHub Pages Documentation](https://docs.github.com/pages)
- [Netlify Deploy](https://docs.netlify.com/deployments/)
- [Vercel Angular Deployment](https://vercel.com/docs/concepts/frameworks/angular)

---

**Built with ❤️ by Mohammad Thiab**